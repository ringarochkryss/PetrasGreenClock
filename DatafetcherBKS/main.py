from fastapi import FastAPI, HTTPException, Request
import requests
import psycopg2
import uvicorn
import os
from dotenv import load_dotenv
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import InstalledAppFlow
from google.auth.transport.requests import Request as GoogleRequest

load_dotenv()
app = FastAPI()

# PostgreSQL-connection
DB_HOST = os.getenv("DB_HOST")
DB_NAME = os.getenv("DB_NAME")
DB_USER = os.getenv("DB_USER")
DB_PASS = os.getenv("DB_PASS")

# Google Places API-key
API_KEY = os.getenv("GOOGLE_PLACES_API_KEY")
Client_ID = os.getenv("GOOGLE_PLACES_CLIENT_ID")
Client_Secret = os.getenv("GOOGLE_PLACES_CLIENT_SECRET")

print(f"API Key: {API_KEY}") 

# Function to get access token
def get_access_token():
    flow = InstalledAppFlow.from_client_secrets_file(
        'client_secret_681955562452-dhsi1o3umdj35pq8i00oiccgklbmdeqf.apps.googleusercontent.com.json',  # Path to your client_secret.json file
        scopes=['https://www.googleapis.com/auth/places']
    )
    flow.redirect_uri = 'http://localhost:8000'
    credentials = flow.run_local_server(port=8080)
    return credentials.token


# Get company data from google
def get_company(name: str):
    access_token = get_access_token()
    url = f"https://maps.googleapis.com/maps/api/place/textsearch/json?query={name}&key={API_KEY}"
    headers = {
        "Authorization": f"Bearer {access_token}"
    }
    response = requests.get(url, headers=headers).json()
    print(f"Request URL: {url}")
    print(f"Response: {response}")
    return response["results"]

# Endpoint: Get company data
# fastapi will automatically convert the response to JSON
@app.get("/company/{name}")
def fetch_company(name: str):
    company_list = get_company(name)
    return {"company": company_list}

# Endpoint: Test the API
@app.get("/")
def home():
    return {"message": "Company API running!"}

if __name__ == "__main__":
    import uvicorn
    print("Starting server on http://127.0.0.1:8000")
    uvicorn.run(app, host="127.0.0.1", port=8000)

