from bisect import bisect_right
import tkinter as tk
from datetime import datetime, timedelta
from screeninfo import get_monitors
import pytz
import os
import subprocess
from ctypes import windll
import keyboard # type: ignore
from tibber import fetch_tibber_prices
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from garbage import get_next_pickups
from birthdays import get_upcoming_birthdays
import matplotlib.pyplot as plt
from PIL import Image, ImageTk

# 🎨 Style
BG_COLOR = "#f2f2f2"
CARD_BG = "#ffffff"
TEXT_COLOR = "#333333"
FONT_SMALL = ("Segoe UI", 9)
FONT_TITLE = ("Segoe UI", 10, "bold")

# 🖥 Position
monitors = get_monitors()
screen = monitors[1] if len(monitors) > 1 else monitors[0]
panel_width = 260
panel_height = 350
x = screen.x + screen.width - panel_width - 10
y = screen.y + 40

root = tk.Tk()
root.title("Petra")
root.geometry(f"{panel_width}x{panel_height}+{x}+{y}")
root.configure(bg=BG_COLOR)
root.attributes("-topmost", True)
root.attributes("-alpha", 0.95)



# 🖼 Layout setup
def get_week_number():
    return f"Vecka {datetime.today().isocalendar()[1]}"

week_label = tk.Label(root, text=f"📅 {get_week_number()}",
                      font=FONT_SMALL, bg=BG_COLOR, fg="#4a90e2", anchor="w")
week_label.pack(pady=(6, 0), padx=10, anchor="w")

# 📦 Card builder
def create_data_card(icon, text="", full_width=False):
    frame = tk.Frame(root, bg=CARD_BG)
    frame.pack(pady=4, padx=10, fill="x" if full_width else "none")
    label = tk.Label(frame, text=f"{icon} {text}",
                 font=FONT_SMALL, bg=CARD_BG,
                 fg="#4a90e2", anchor="w")  # Example: soft blue
    label.pack(padx=8, pady=5)
    return label

# 🗑️ Garbage info card at bottom
pickup_card = tk.Frame(root, bg=CARD_BG)
pickup_card.pack(side="bottom", pady=0, padx=10, fill="x")

pickup_label = tk.Label(pickup_card, text="Loading...", font=FONT_SMALL, bg=CARD_BG, fg="#4a90e2", anchor="w")
pickup_label.pack(padx=8, pady=0, anchor="w")

icon_frame = tk.Frame(pickup_card, bg=CARD_BG)
icon_frame.pack(padx=8, pady=0, anchor="w")


# 🗑️ Bin icons
ASSETS = os.path.join(os.path.dirname(__file__), "Assets")
BIN_IMAGES = {}

def load_bin_images():
    global BIN_IMAGES
    BIN_IMAGES = {
        "1_normal": ImageTk.PhotoImage(Image.open(os.path.join(ASSETS, "bin1blue.png")).resize((20, 27))),
        "2_normal": ImageTk.PhotoImage(Image.open(os.path.join(ASSETS, "bin2blue.png")).resize((20, 27))),
        "1_alert": ImageTk.PhotoImage(Image.open(os.path.join(ASSETS, "bin1red.png")).resize((20, 27))),
        "2_alert": ImageTk.PhotoImage(Image.open(os.path.join(ASSETS, "bin2red.png")).resize((20, 27)))
    }


# 📅 Fixed meeting labels
meeting_frame = tk.Frame(root, bg=CARD_BG)
meeting_frame.pack(pady=4, padx=10, fill="x")

next_label = tk.Label(meeting_frame, text="Kalender", font=FONT_SMALL, bg=CARD_BG, fg="#4a90e2", anchor="w")
next_label.pack(anchor="w", padx=8, pady=(6, 0))

meeting_time_label = tk.Label(meeting_frame, text="", font=("Segoe UI", 12, "bold"), bg=CARD_BG, fg="#4a90e2", anchor="w")
meeting_time_label.pack(anchor="w", padx=8, pady=(2, 0))

meeting_subject_label = tk.Label(meeting_frame, text="", font=("Segoe UI", 8), bg=CARD_BG, fg="#4a90e2", anchor="w")
meeting_subject_label.pack(anchor="w", padx=8, pady=(2, 6))

# 🎂 Birthday list
birthday_card = tk.Frame(root, bg=CARD_BG)
birthday_card.pack(pady=2, padx=10, fill="x")

birthday_list_frame = tk.Frame(birthday_card, bg=CARD_BG)
birthday_list_frame.pack(padx=8, pady=(0, 6), anchor="w")

# 📊 Graph system
graph_visible = False
current_graph_canvas = []

def toggle_graph():
    global graph_visible, current_graph_canvas

    if graph_visible:
        for canvas in current_graph_canvas:
            canvas.get_tk_widget().destroy()
        current_graph_canvas = []
        graph_visible = False
        root.geometry(f"{panel_width}x{panel_height}+{x}+{y}")
        toggle_button.config(text="📊")
        return

    new_width = panel_width * 3
    new_height = screen.height
    new_x = screen.x + screen.width - new_width - 10
    root.geometry(f"{new_width}x{new_height}+{new_x}+0")

    def make_chart(day, title):
        data = fetch_tibber_prices().get(day, [])
        if not data:
            print(f"No {day} data")
            return

        prices = [h["total"] for h in data]
        labels = [datetime.fromisoformat(h["startsAt"]).strftime("%H") for h in data]
        x_positions, x = [], 0
        for i in range(len(prices)):
            x_positions.append(x)
            x += 0.9 if (i + 1) % 4 else 1.2
        colors = ["red" if p > 1.0 else "green" for p in prices]

        fig, ax = plt.subplots(figsize=(9, 3.5))
        ax.bar(x_positions, prices, width=0.8, color=colors)
        ax.set_title(title, fontsize=10)
        ax.set_ylabel("SEK/kWh", fontsize=7)
        ax.set_xlabel("Hour", fontsize=7)
        ax.set_xticks(x_positions)
        ax.set_xticklabels(labels, fontsize=6)
        ax.tick_params(axis="y", labelsize=6)
        ax.grid(axis="y", linestyle=":", alpha=0.3)

        canvas = FigureCanvasTkAgg(fig, master=root)
        canvas.draw()
        canvas.get_tk_widget().configure(highlightthickness=0, bd=0)
        canvas.get_tk_widget().pack(pady=4)
        current_graph_canvas.append(canvas)

        if day == "today":
            now_hour = datetime.now().strftime("%H")
            current_price = next((p["total"] for p in data if datetime.fromisoformat(p["startsAt"]).strftime("%H") == now_hour), None)
            if current_price:
                price_label.config(text=f"⚡ {current_price:.2f} SEK/kWh")

    make_chart("today", "Elpris idag")
    make_chart("tomorrow", "Elpris imorgon")
    graph_visible = True
    toggle_button.config(text="❌")

# 🔄 Time update
def get_time_in(zone):
    return datetime.now(pytz.timezone(zone)).strftime("%H:%M")

def update_labels():
    swe_label.config(text="🇸🇪 " + get_time_in("Europe/Stockholm"))
    hels_label.config(text="🇫🇮 " + get_time_in("Europe/Helsinki"))
    hk_label.config(text="🇭🇰 " + get_time_in("Asia/Hong_Kong"))
    root.after(1000, update_labels)

# 📅 Meeting

def get_meeting_txt_path():
    return os.path.join(os.path.abspath("."), "meeting.txt")

def load_meeting_from_file():
    path = get_meeting_txt_path()
    if os.path.exists(path):
        try:
            with open(path, "r", encoding="utf-8") as f:
                return f.read().strip()
        except:
            return ""
    return ""

def run_powershell_script():
    path = os.path.join(os.path.dirname(__file__), "get_meeting.exe")
    if os.path.exists(path):
        try:
            subprocess.run([path], capture_output=True, text=True)
        except:
            pass

def update_meeting():
    global meeting_time_label, meeting_subject_label
    run_powershell_script()
    week_label.config(text=f"📅 {get_week_number()}")

    raw_data = load_meeting_from_file()
    time_str, subject = "", ""

    if " - " in raw_data:
        time_str, subject = map(str.strip, raw_data.split(" - ", 1))
    else:
        subject = raw_data.strip()
        time_str = ""

    try:
            meeting_time = datetime.strptime(time_str, "%H:%M")
            meeting_time = datetime.strptime(time_str, "%H:%M")
            now = datetime.now()
            today_meeting = now.replace(hour=meeting_time.hour, minute=meeting_time.minute, second=0, microsecond=0)
            time_diff = today_meeting - now

            if timedelta(minutes=0) <= time_diff <= timedelta(minutes=5):
                mins_left = int(time_diff.total_seconds() / 60)
                meeting_subject_label.config(text=f"⏳ {mins_left} min kvar – {subject}")
                meeting_time_label.config(text=time_str, fg="#ff4444")  # Red text
                meeting_frame.config(highlightbackground="#ffd700", highlightthickness=2, bd=0)  # Golden glow
            else:
                meeting_time_label.config(text=time_str, fg=TEXT_COLOR)
                meeting_subject_label.config(text=subject if subject else "Laddar möte...")
                meeting_frame.config(highlightthickness=0)
    except:
            meeting_time_label.config(text=time_str)
            meeting_subject_label.config(text=subject if subject else "Laddar möte...")
            meeting_frame.config(highlightthickness=0)

    root.after(300000, update_meeting)

    # 🎂Birthday reminder
def update_birthdays():
    for widget in birthday_list_frame.winfo_children():
        widget.destroy()

    birthdays = get_upcoming_birthdays("birthdays.json")
    today = datetime.today().date()

    for entry in birthdays:
        color = "#ff4444" if (entry["date"] - today).days == 1 else "#4a90e2"

        lbl = tk.Label(
            birthday_list_frame,
            text=f"🎂 {entry['text']}",
            font=FONT_SMALL,
            bg=CARD_BG,
            fg=color,
            anchor="w"
        )
        lbl.pack(anchor="w")

    root.after(86400000, update_birthdays)

# 🗑️ Garbagetext
def update_pickup():
    for widget in icon_frame.winfo_children():
        widget.destroy()

    pickups = get_next_pickups("garbage.json")
    if not pickups:
        pickup_label.config(text="No pickup info", fg="#4a90e2")
        return

    today = datetime.today().date()
    next_date = pickups[0]["date"]
    highlight = (next_date - today == timedelta(days=1))
    color = "#ff4444" if highlight else "#4a90e2"

    # Format date as Tue 22/7
    date_text = next_date.strftime("%a %d/%m").replace("/0", "/")  # optional: remove leading zeros

    # Clear main label (we’ll show icon and date separately)
    pickup_label.config(text="", fg=color)

    # Display icons + date beside each
    for p in pickups:
        bin_num = p["bin"]
        key = f"{bin_num}_{'alert' if highlight else 'normal'}"
        image = BIN_IMAGES.get(key)

        bin_frame = tk.Frame(icon_frame, bg=CARD_BG)
        bin_frame.pack(side="left", padx=6)

        if image:
            img_label = tk.Label(bin_frame, image=image, bg=CARD_BG)
            img_label.image = image
            img_label.pack(pady=(0, 0))

        date_label = tk.Label(bin_frame, text=date_text, font=FONT_SMALL, fg=color, bg=CARD_BG)
        date_label.pack(pady=(0, 0))
    
    root.after(86400000, update_pickup)


# ⚡ Electricity price
def update_price():
    data = fetch_tibber_prices().get("today", [])
    if not data:
        print("⚡ No price data")
        return

    now_hour = datetime.now().strftime("%H")
    current_price = next((p["total"] for p in data if datetime.fromisoformat(p["startsAt"]).strftime("%H") == now_hour), None)
    if current_price:
        price_label.config(text=f"⚡ {current_price:.2f} SEK/kWh")
        print(f"🕒 Price: {current_price:.2f}")
    root.after(300000, update_price)




clock_row = tk.Frame(root, bg=BG_COLOR)
clock_row.pack(pady=4)

swe_label = create_data_card("🇸🇪", "", full_width=False)
hels_label = create_data_card("🇫🇮", "", full_width=False)
hk_label = create_data_card("🇭🇰", "", full_width=False)

swe_label.master.pack(in_=clock_row, side="left", padx=5)
hels_label.master.pack(in_=clock_row, side="left", padx=5)
hk_label.master.pack(in_=clock_row, side="left", padx=5)

graph_row = tk.Frame(root, bg=BG_COLOR)
graph_row.pack(pady=6)

toggle_button = tk.Button(
    graph_row,
    text="📊 Elpris",
    command=toggle_graph,
    font=("Segoe UI", 9),
    bg="#4a90e2",               # Blue background
    fg="#ffffff",               # White text
    activebackground="#3a78c2", # Darker blue when clicked
    activeforeground="#ffffff", # Keeps white text
    relief="raised",            # Gives 3D button feel
    borderwidth=2,
    cursor="hand2"
)

toggle_button.pack(side="left", padx=4)

price_label = tk.Label(graph_row, text="⚡ Laddar pris...", font=FONT_SMALL,
                       bg=BG_COLOR, fg="#4a90e2", anchor="w")
price_label.pack(side="left", padx=6)

#MoveTheMouse
def simulate_activity():
    try:
        keyboard.press_and_release('shift')  # Du kan byta till 'ctrl' eller annan tangent
    except:
        pass
    root.after(240000, simulate_activity)  # Kör var 4:e minut

# 🚀 Startup
update_labels()
update_meeting()
update_price()
simulate_activity()
load_bin_images()
update_pickup()
update_birthdays()
root.mainloop()
