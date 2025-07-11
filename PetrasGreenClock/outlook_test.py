import win32com.client

try:
    outlook = win32com.client.Dispatch("Outlook.Application")
    namespace = outlook.GetNamespace("MAPI")
    inbox = namespace.GetDefaultFolder(6)  # 6 = Inkorgen
    print("✅ Outlook är installerat och tillgängligt!")
except Exception as e:
    print("❌ Outlook hittades inte eller kunde inte öppnas.")
    print(e)
