# Overview
[![wakatime](https://wakatime.com/badge/github/GoodPro712/SoundsGoodToMe.svg)](https://wakatime.com/badge/github/GoodPro712/SoundsGoodToMe)
[![CodeFactor](https://www.codefactor.io/repository/github/goodpro712/soundsgoodtome/badge)](https://www.codefactor.io/repository/github/goodpro712/soundsgoodtome)
![GitHub repo size](https://img.shields.io/github/repo-size/goodpro712/soundsgoodtome)
![Lines of code](https://img.shields.io/tokei/lines/github/goodpro712/soundsgoodtome)
![GitHub](https://img.shields.io/github/license/goodpro712/soundsgoodtome)
![GitHub last commit](https://img.shields.io/github/last-commit/goodpro712/soundsgoodtome)
![GitHub release (latest SemVer including pre-releases)](https://img.shields.io/github/v/release/goodpro712/soundsgoodtome?include_prereleases&sort=semver)

**Command line program to overlay "Sounds Good To Me" on a provided gif.**

**Built with [CliFx](https://github.com/Tyrrrz/CliFx) and [SpectreConsole](https://github.com/spectreconsole/spectre.console).**

![sgtm_1630582259481](https://user-images.githubusercontent.com/45357714/131836454-68e9c9dc-e2f5-48c4-84de-5277c4c38c25.gif)

## Contents
- [Features](#features)
    - [Url Support](#url-support)
    - [File Support](#file-support)
    - [Easy-to-read Help Messages](#easy-to-read-help-messages)
    - [Customizable Output Directory](#customizable-output-directory)
    - [Customizable Font](#customizable-font)
    - [Customizable Text Color](#customizable-text-color)
- [Setup](#setup)
- [Commands](#commands)
    - [ConvertUrl](#converturl)
    - [ConvertFile](#convertfile)
- [Examples](#examples)
- [Support](#support)
- [License](#license)

## Features
### Url Support
Overlay text on gifs from a gif url with the `--url` or `-u` switch. Error thrown if the gif from the link does not result in a .gif format.

![output](https://user-images.githubusercontent.com/45357714/131810218-49cde778-9281-4683-9a85-e66c1555505e.gif)

### File Support
Overlay text on gifs from an existing gif file with the `--path` or `-p` switch.
Error thrown if the file is the wrong format, or the program was not run with the permissions needed to access the file

![output](https://user-images.githubusercontent.com/45357714/131811050-907931f3-d43c-4156-9b3e-201a6d22c019.gif)

### Easy-to-read Help Messages
Colorful, easy to read, automatically generated help messages.

![nothing](https://user-images.githubusercontent.com/45357714/131811267-5a4ab4c3-af13-4edf-800e-d113ec1c3cc8.png)

![converturlhelp](https://user-images.githubusercontent.com/45357714/131811509-05318ee5-e3fd-4a8d-97b0-ab73f0e047ea.png)

![convertfilehelp](https://user-images.githubusercontent.com/45357714/131811514-d9ca0471-3964-4cf3-b571-e712c383ebe3.png)

### Customizable Output Directory
Change the output directory for the finished and temporary gifs with the `--output` or `-o` switch.
Default directory is `/UserFolder/sgtm-output/`

![image](https://user-images.githubusercontent.com/45357714/131813606-1a3bb0f2-d1a7-4a44-9942-af360627a12f.png)

### Customizable Font
Change the font used to draw text with the `--font` or `-f` switch.
Default font is Arial. If you are getting errors with the default font, make sure Arial is installed.
[(How to install Arial on Ubuntu)](https://askubuntu.com/questions/651441/how-to-install-arial-font-and-other-windows-fonts-in-ubuntu)

![image](https://user-images.githubusercontent.com/45357714/131814088-9f8ed19a-96ab-48bf-8a01-7ceb63ffc579.png)

### Customizable Text Color
Change the text color used to draw text with the `--color` or `-c` switch.
Default color is #FFFFFF (White). Make sure this color is a hex value.

![image](https://user-images.githubusercontent.com/45357714/131814904-4ae06504-8dc2-4ba0-8b02-e4bba79faf80.png)

## Setup
(Assuming [.NET Core 3.1](https://dotnet.microsoft.com/download) and an archive manager is installed)
- Download the latest binary from the [releases](https://github.com/GoodPro712/SoundsGoodToMe/releases) page.
- Extract the binary with your favourite archive manager (Mine being [7zip](https://www.7-zip.org/)).
- Open a terminal window in the directory the folder was extracted to
- Type `dotnet SoundsGoodToMe.dll --help` and follow the help message.

## Commands

| command | desc |
| - | - |
[converturl](#converturl) | overlays "Sounds Good To Me" onto an image fetched from a url
[convertfile](#convertfile) | overlays "Sounds Good To Me" onto a pre-existing file
version | responds with the version the program is running on

### ConvertUrl
| switch | required | desc |
| - | - | - |
`--url` or `-u` | `true` | url used to fetch gif
`--outputdir` or `-o` | `false` | output directory for the converted gifs
`--font` or `-f` | `false` | font used for text overlay
`--color` or `-c` | `false` | color used for text overlay
`--help` or `-h` | `false` | displays a help message on all switches

### ConvertFile
| switch | required | desc |
| - | - | - |
`--path` or `-p` | `true` | path to the file to be converted
`--outputdir` or `-o` | `false` | output directory for the converted gifs
`--font` or `-f` | `false` | font used for text overlay
`--color` or `-c` | `false` | color used for text overlay
`--help` or `-h` | `false` | displays a help message on all switches

## Examples
- Convert a gif from the url `https://somewebsite.com/anime-girl.gif` to save at the output folder of `/home/charlie/sgtm/output/` with the font `Ubuntu` with text written in color black (`#000000`).
```bash
dotnet SoundsGoodToMe.dll converturl -u https://somewebsite.com/anime-girl.gif -o /home/charlie/sgtm/output/ -f Ubuntu -c #000000
```

- Convert a gif from a pre-existing file located at `/home/charlie/Desktop/anime-girl.gif` to save at the output folder of `/home/charlie/applications/sgtm/output/` with the font `Ubuntu` with text written in color red (`#000000`).
```bash
dotnet SoundsGoodToMe.dll convertfile -p /home/charlie/Desktop/anime-girl.gif -o /home/charlie/applications/sgtm/output/ -f Ubuntu -c #FF0000
```

- Get the current version of the app.
```bash
dotnet SoundsGoodToMe.dll --version
```

- Display a help message on the `convertfile` command.
```bash
dotnet SoundsGoodToMe.dll convertfile -h
```

## Support
For any bug reports, questions, or requests, create an issue via the [issue tracker](https://github.com/GoodPro712/SoundsGoodToMe/issues).

## License
SoundsGoodToMe is released under the [MIT License](https://github.com/GoodPro712/SoundsGoodToMe/blob/master/LICENSE).
