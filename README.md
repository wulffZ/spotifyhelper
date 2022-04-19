<h1 align="center">Spotify Helper</h1>

<p align="center">End-user commandline application that converts youtube links into datarich spotify local files.</p>

## Download

Windows: http://sharefiles.tk/guest/6bx6t
Linux: http://sharefiles.tk/guest/cTilK

## How it works
- Downloads the youtube video and saves to .mp4
- Converts the .mp4 to an .mp3
- Downloads highest available quality thumbnail and adds that and writes a copy of the .mp3 now with added metadata.
- Places the .mp3 in the configurable final destination folder.

## Why use it?
- Because using youtube downloader services suck
- It saves only the final .mp3, and uses your OS's specific temporary folder to convert etc, leaving no traces behind.
- Its simple CLI, no messing with a gui give it a link and it will do its thing.
 

## Installation and how to use.

Installation
1. Download the zip for your OS and extract into desired folder (including the App.config!).
2. Configure App.config
3. Run the executeable and pray.

Thats it!

## Configuring App.config
1. Open in your favorite text editor
2. Under the key FFMPEGExeLocation paste the **absolute** path to your ffmpeg executeable. By default the application will assume ffmpeg is in your PATH.
3. Under the key DestinationDirPathLinux or Windows paste the absolute path to the folder you want the final product to be placed into.

## Built With

- C#

## Operation system support
- Linux
- Windows

## Future Updates

- [ ] Support for adding more .mp3 informations including authors, release date, album.
- [ ] Android app?

## Author

**Matthijs van Zetten**

- [Profile](https://github.com/wulffZ "Matthijs van Zetten")
- [Email]("mattje74@gmail.com")

