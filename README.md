# KH Switcher

![KH Switcher Hero](Support/Readme%20Images/KHSwitcherHero.jpeg)

### A simple tool to make hybrid meetings easier

KH Switcher is designed to simplify the management of hybrid meetings, allowing for easy control of displays, media, and camera shots. Its user-friendly interface and advanced features can improve the meeting quality while reducing the necessary skills required to operate it. It removes the need for using the Share Screen function of Zoom and provides one click operation of PTZ cameras. 

# 🎉 What's New in Version 3
Version 3 is a major update that introduces lots of new features. Here's some of the most noteworthy:

- New settings menu make it much easier to setup and change optional features
- KH Switcher now prompts users when an update is available
- OnlyM can now be hidden in the settings for congregations who don't use OnlyM
- Settings can now be exported/imported to backup current configurations and to make migrating to new computers easier
- New icons update the look and give extra context. For example a KH Switcher now detects when a scene has Display Capture and changes the icon to match
- Option to select the correct second display ensures correct functionality
- Added a refresh button to KH Switcher Zoom that reconnects and updates with the latest scenes
- Plus more fixes and improvements...
  
  
>[!note] Migration Note
When upgrading from v2 to v3, the application will attempt to automatically migrate your existing settings. To ensure that migration is successful, please make sure to have at least v2.0.0.2 installed in the default install location before upgrading. 

## Requirements 

* Windows 10 or 11
* OBS studio version 30

## How to install?

To get started with KH Video Switcher please download the latest release from the [releases](https://github.com/aaroned/KH-Video-Switcher/releases) page. The installer will guide you through the initial setup and will automatically configure your local network. 

## How to Setup (Basic Guide)
This is a brief guide to setting up KH Switcher. For further explanation and more advanced configurations please see the [wiki](https://github.com/aaroned/KH-Video-Switcher/wiki).

1. Start OBS and create scenes for camera and media capture. Next enable the Websocket by going to
``` Tools > Websocket Server Settings > ✅ Enable Websocket Server ```. Click ``` Show Connection Info ``` and take note of the server password.
2. Open KH Switcher (Media) and navigate to ``` File > Settings > OBS Connection ```. Enter the server password and test the connection. If connection is successful save the settings. 
3. Open KH Switcher (Zoom) and check connection is successful. 

That's it! For most congregations installing KH Switcher (Media) and KH Switcher (Zoom) on the same system as OBS there are no further changes to be made. 

## Help

For more instructions on how KH Switcher works and how to configure it as well as OBS for complete functionality, please see the [wiki](https://github.com/aaroned/KH-Video-Switcher/wiki).

If you have consulted the documentation and are unable to resolve your issue please submit an report.
