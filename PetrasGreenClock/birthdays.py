import json
from datetime import datetime, timedelta

def get_upcoming_birthdays(json_path="birthdays.json"):
    try:
        with open(json_path, "r", encoding="utf-8") as f:
            data = json.load(f)
    except Exception as e:
        print("Error reading birthdays.json:", e)
        return []

    today = datetime.today().date()
    current_year = today.year

    upcoming = []

    for entry in data:
        try:
            day, month = map(int, entry["date"].split("/"))
            birthday_date = datetime(current_year, month, day).date()
            # Om vi redan har passerat födelsedagen i år, räkna på nästa år
            if birthday_date < today:
                birthday_date = datetime(current_year + 1, month, day).date()
            days_until = (birthday_date - today).days
            age = entry["age_2025"] + (birthday_date.year - 2025)

            upcoming.append({
                "date": birthday_date,
                "days_until": days_until,
                "text": f"{entry['date']} – {entry['name']} {age} år"
            })
        except:
            continue

    upcoming.sort(key=lambda x: x["date"])

    if any(p["days_until"] <= 7 for p in upcoming):
        return [p for p in upcoming if p["days_until"] <= 7][:3]
    elif upcoming:
        return [upcoming[0]]
    return []
