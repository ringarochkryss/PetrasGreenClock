import json
from datetime import datetime, timedelta

def get_next_pickups(json_path="garbage.json"):
    try:
        with open(json_path, "r", encoding="utf-8") as f:
            data = json.load(f)
    except Exception as e:
        print("Error reading garbage.json:", e)
        return []

    today = datetime.today().date()
    pickups = []

    # Read and filter future pickups for each bin
    for bin_key in ["bin_1", "bin_2"]:
        for date_str in data.get(bin_key, []):
            try:
                pickup_date = datetime.strptime(date_str, "%Y-%m-%d").date()
                if pickup_date >= today:
                    pickups.append({
                        "date": pickup_date,
                        "bin": bin_key[-1]  # Get "1" or "2"
                    })
            except:
                continue

    if not pickups:
        return []

    # Sort pickups and find the next date
    pickups.sort(key=lambda x: x["date"])
    next_date = pickups[0]["date"]

    # Return all pickups on that same day
    same_day = [p for p in pickups if p["date"] == next_date]
    return same_day
