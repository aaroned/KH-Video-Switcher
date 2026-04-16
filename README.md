# KH Switcher

![KH Switcher Hero](Support/Readme%20Images/hero-v3.png)

## Simple AV switching for hybrid meetings

KH Switcher is designed to simplify hybrid meetings, allowing for easy control of displays, media, and camera angles. Its user-friendly interface and advanced features can improve the meeting quality while also reducing the complexity to operate it. It removes the need for using the Share Screen function of Zoom and provides one click operation of PTZ cameras. 

# 🎉 Version 3 Release Notes
Version 3 is a major update that introduces lots of new features and fixes. Here's some of the most noteworthy:

- A new settings menu make it much easier to setup and change optional features
- KH Switcher now prompts users when an update is available making it easier for your congregation to install the latest version
- OnlyM can now be hidden in the settings for congregations who don't use it
- New icons update the look and give extra context. For example a KH Switcher now detects when a scene has Display Capture and changes the icon to match
- Settings can now be exported/imported to backup current configurations and to make migrating to new computers easier
- Option to select the correct second display ensures correct functionality of Zoom and JW Library
- Added connection indicators to give you confidence that everything is working as it should
- Plus more fixes and improvements...
  
<br>
  
>[!warning] Migration Note
When upgrading from v2 to v3, the application will attempt to automatically migrate your existing settings. To ensure that migration is successful, please make sure to have at least v2.0.0.2 installed in the default install location before upgrading. 

## Requirements 

* Windows 10 or 11 with .NET Framework 4.8 installed
* OBS Studio 30 or later with WebSocket Server enabled

## How to install?

To get started with KH Video Switcher please download the latest release from the [releases](https://github.com/aaroned/KH-Video-Switcher/releases) page. The installer will guide you through the initial setup and will automatically configure your local network. 

## How to Setup (Basic Guide)
This is a brief guide to setting up KH Switcher. For further explanation and more advanced configurations please see the [wiki](https://github.com/aaroned/KH-Video-Switcher/wiki).

1. Install and start OBS. Then create scenes for camera and media capture. Next enable the Websocket by going to
``` Tools > Websocket Server Settings > ✅ Enable Websocket Server ```. Click ``` Show Connection Info ``` and take note of the server password.
2. Open KH Switcher (Media) and navigate to ``` File > Settings > OBS Connection ```. Enter the server password and test the connection. If connection is successful save the settings. 
3. Open KH Switcher (Zoom) and check connection is successful. 

That's it! For most congregations installing KH Switcher (Media) and KH Switcher (Zoom) on the same system as OBS there are no further changes to be made. 

## Help

For more instructions on how KH Switcher works and how to configure it as well as OBS for complete functionality, please see the [wiki](https://github.com/aaroned/KH-Video-Switcher/wiki).

If you have consulted the documentation and are unable to resolve your issue please submit an report.

---

> KH Switcher is an independent, open-source project developed by volunteers. It is not affiliated with, endorsed by, or supported by Jehovah's Witnesses, the Watch Tower Bible and Tract Society, or any related organization.