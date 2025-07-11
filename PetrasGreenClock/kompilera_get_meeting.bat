@echo off
echo.
echo Attempting to close any running get_meeting.exe...
taskkill /f /im get_meeting.exe >nul 2>&1

echo Deleting existing get_meeting.exe if it exists...
del /f /q get_meeting.exe >nul 2>&1

if exist get_meeting.exe (
    echo Could not delete old get_meeting.exe
) else (
    echo Ready to compile new version
)

echo.
echo Compiling get_meeting.exe...

"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe" -ExecutionPolicy Bypass ^
 -File "C:\Users\petra\OneDrive\Dokument\WindowsPowerShell\Modules\ps2exe\1.0.15\ps2exe.ps1" ^
 -inputFile ".\get_meeting.ps1" ^
 -outputFile ".\get_meeting.exe" ^
 -noConsole ^

echo.
if exist get_meeting.exe (
    echo get_meeting.exe successfully compiled
) else (
    echo Something went wrong - .exe was not created
)

echo.
pause
