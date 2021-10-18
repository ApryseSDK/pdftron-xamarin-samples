# About
This sample shows how to use the PDFTron mobile SDK with .NET 6.0 release candidate 1 

**Note:** Official support for the SDK is being implemented.

# Prerequesites

* [.NET 6 SDK Release Candidate 1](https://dotnet.microsoft.com/download/dotnet/6.0)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 
    * Option 1: 2022 Release Candidate or 2022 for Mac Preview 
    * Option 2: 2019 v16.11 or 2019 for Mac v8.10
* [Android 12 SDK](https://developer.android.com/about/versions/12/setup-sdk) 
* [XCode 13](https://developer.apple.com/xcode/) for iOS

# Instructions

1. Run the following commands in your terminal:
    ```
    dotnet workload install android
    dotnet workload install ios
    dotnet workload install maui
    dotnet workload install maui-mobile
    dotnet workload install maui-android
    dotnet workload install maui-ios
    ```

## .NET 6 for Android

2. Open the [`Net6Android`](./Net6Android) project in Visual Studio.
3. Restore the packages.
4. Run the project.

## .NET 6 for iOS

2. Open the [`Net6iOS`](./Net6iOS) project in Visual Studio.
3. Restore the packages.
4. Run the project.

## .NET MAUI

2. Open the [`Net6MAUI`](./Net6MAUI) project in Visual Studio.
3. Restore the packages.
4. Choose the platform that you want to run on.
5. Run the project.