# TDIN_Chat

## Compile

If you have visual studio installed in an windows machine, then you have a program called "Developer PowerShell for VS 2019". Has all the Visual Studio tools available through command line. Open it in the root of this project and type:

```ps
# Executes the build script 
.\compilation\compile.ps1      
```

This script will create two folders: "build" and "temp". "build" is where the .dll files and .exe files will be stored. "temp" is where the created users will be stored.

After running the script go to the "build" folder in the file explorer. First open one instance of "ServerFram.exe". Then open has many instances of "WPFUI.exe" files as you want.