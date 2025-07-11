@echo off
echo === Rebuilding get_meeting.exe ===

rem Step 1: Set full path to powershell.exe
set pwsh=C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe

rem Step 2: Delete previous .exe if it exists
if exist get_meeting.exe (
    echo Deleting old get_meeting.exe...
    del get_meeting.exe
)

rem Step 3: Install ps2exe if needed
%pwsh% -ExecutionPolicy Bypass -Command ^
"if (-not (Get-Module -ListAvailable -Name ps2exe)) { ^
    Write-Host 'Installing ps2exe...'; ^
    Install-Module -Name ps2exe -Scope CurrentUser -Force -AllowClobber ^
}"

rem Step 4: Build silent .exe
%pwsh% -ExecutionPolicy Bypass -Command ^
"Invoke-PS2EXE -InputFile 'get_meeting.ps1' -OutputFile 'get_meeting.exe' -noConsole -noOutput"

rem Step 5: Confirm success
if exist get_meeting.exe (
    echo Success! Silent get_meeting.exe created.
) else (
    echo Failed to create get_meeting.exe.
)

pause
