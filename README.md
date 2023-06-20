# LTSaveEd [![Licensed under the MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/Exiua/LTSaveEd/blob/master/LICENSE)
[![Release Version](https://img.shields.io/github/v/release/Exiua/LTSaveEd?include_prereleases)](https://github.com/Exiua/LTSaveEd/releases) ![GitHub all releases](https://img.shields.io/github/downloads/Exiua/LTSaveEd/total)

LTSaveEd is a save editor for the game _Lilith's Throne_ built using Java 14 and JavaFx 16.

## Requirements
Requires Java 14 or later if you are just running the .jar. Requires JavaFx 16 or later as well if you need to compile the program yourself.

## How To Use

Download and run `LTSaveEd.jar` (or `LTSaveEd.exe`[^1]) from the [latest release](https://github.com/Exiua/LTSaveEd/releases). If nothing happens when you double-click the jar, try running `java -jar LTSaveEd.jar`. If you have multiple versions of Java installed, try `/path/to/java14+_jdk/bin/java.exe -jar LTSaveEd.jar`.

If the jar doesn't work, download and extract the zip from the [latest release](https://github.com/Exiua/LTSaveEd/releases) and add `--module-path /path/to/javafx-sdk-16/lib --add-modules=javafx.controls,javafx.fxml` as a VM option to your run configuration, then run `LTSaveEd.java`.

***Make a backup of your save first before using the save editor.***

[^1]: The exe was only testing on Windows 10. The exe is also unsigned, so Windows Defender SmartScreen may warn you that running unsigned exe is potentially dangerous. 

## Features
- Edit both player and NPCs
- Change name and description of player/NPCs
- Adjust stats and attributes (level, money, health, etc.)
- Modify body configuration
- Adjust Fetishes, Perks, and Spells
- Remove/Modify inventory (cannot add items yet)
- Modify relationships and family
- Adjust global values (ingame date, stamps, etc.)
- Remove all non-encountered offsprings
- Reveal the map

## Troubleshooting
- A popup saying "This application requires a Java Runtime Environment ##"
  - Try running `java --version` or `java -version` in a terminal. If the output says `java 1.8`, you have Java 8 installed. You can download the latest version of Java from [here](https://www.oracle.com/java/technologies/downloads/)

