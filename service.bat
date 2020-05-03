ECHO OFF
cls
:menu
cls
ECHO.
ECHO ...............................................
ECHO PRESS 1, 2 OR 3 to select your task, or 4 to EXIT.
ECHO ...............................................
ECHO.
ECHO 1 - install service
ECHO 2 - Start service
ECHO 3 - stop service
ECHO 4 - uninstall service
ECHO.


SET /P M=Type 1, 2, 3, or 4 then press ENTER:
IF %M%==1 GOTO inst
IF %M%==2 GOTO starts
IF %M%==3 GOTO stops
IF %M%==4 GOTO uninst


:inst
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe" "S:\OneDrive\Developement\c-sharp\NetTracker\NetTracker\bin\Debug\NetTracker.exe"
GOTO menu

:starts
NET START NetTracker
GOTO menu

:stops
NET STOP NetTracker
GOTO menu


:uninst
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe" "S:\OneDrive\Developement\c-sharp\NetTracker\NetTracker\bin\Debug\NetTracker.exe" /u
GOTO menu