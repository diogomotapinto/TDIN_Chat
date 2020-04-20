$LOCATION = Get-location
$BUILD_DIR = "$LOCATION\build"
$DATABASE_DIR = "$LOCATION\temp"

# BUILD DIR CREATION
if(!(Test-Path "$BUILD_DIR\")) {
    Write-Host "$BUILD_DIR\ didn't exist will try to create it."

    New-Item -Path $BUILD_DIR\ -ItemType Directory

    if(Test-Path "$BUILD_DIR\") {
        Write-Host "Build path created successfully."
    }
    else {
        Write-Host "Failed to create build path. Exiting..."
        [Environment]::Exit(1)
    }
}

# TEMP DIR CREATION
if(!(Test-Path "$DATABASE_DIR\")) {
    Write-Host "$DATABASE_DIR\ didn't exist will try to create it."

    New-Item -Path $DATABASE_DIR\ -ItemType Directory

    if(Test-Path "$DATABASE_DIR\") {
        Write-Host "Database path created successfully."
    }
    else {
        Write-Host "Failed to create database path. Exiting..."
        [Environment]::Exit(1)
    }
}

# COMPILE WPF APP
$WPF_BUILD_RESULT = msbuild "$LOCATION\WPFUI\WPFUI.csproj" /t:Build /p:OutDir=$BUILD_DIR;

if($?) {
    Write-Host "WPF client app build succeeded."
}
else {
    Write-Host "Failed to build WPF client app. Here is the output:"
    Write-Host $WPF_BUILD_RESULT
    [Environment]::Exit(1)
}

# COMPILE SERVER APP
$SERVER_BUILD_RESULT = msbuild "$LOCATION\ServerFram\ServerFram.csproj" /t:Build /p:OutDir=$BUILD_DIR;

if($?) {
    Write-Host "Server app build succeeded."
}
else {
    Write-Host "Failed to build Server app. Here is the output:"
    Write-Host $WPF_BUILD_RESULT
    [Environment]::Exit(1)
}

if(!((Test-Path "$BUILD_DIR\WPFUI.exe") -AND (Test-Path "$BUILD_DIR\ServerFram.exe"))) {
    Write-Host "Executable files weren't found in the correct place."
    [Environment]::Exit(1)
}

Write-Host "Build succeeded. Now you can run the apps:"
Write-Host "$BUILD_DIR\WPFUI.exe and $BUILD_DIR\ServerFram.exe"