import requests
import os
from dotenv import load_dotenv

# Load the Tibber token from .env
load_dotenv()
TIBBER_TOKEN = os.getenv("TIBBER_TOKEN")

def fetch_tibber_prices():
    if not TIBBER_TOKEN:
        print("Error: TIBBER_TOKEN is missing or not loaded.")
        return {"today": [], "tomorrow": []}

    query = """
    {
      viewer {
        homes {
          currentSubscription {
            priceInfo {
              today {
                total
                startsAt
              }
              tomorrow {
                total
                startsAt
              }
            }
          }
        }
      }
    }
    """
    url = "https://api.tibber.com/v1-beta/gql"
    headers = {
        "Authorization": f"Bearer {TIBBER_TOKEN}",
        "Content-Type": "application/json"
    }

    try:
        response = requests.post(url, json={"query": query}, headers=headers)
        print("HTTP status:", response.status_code)
        print("Raw response:", response.text)

        data = response.json()
        home = data["data"]["viewer"]["homes"][0]
        today = home["currentSubscription"]["priceInfo"].get("today", [])
        tomorrow = home["currentSubscription"]["priceInfo"].get("tomorrow", [])

        return {
            "today": today,
            "tomorrow": tomorrow
        }

    except Exception as e:
        print("Failed to fetch or parse Tibber response:", e)
        return {"today": [], "tomorrow": []}