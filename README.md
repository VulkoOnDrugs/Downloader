
# Downloader

A simple **Windows console app** built with **.NET 10** that downloads videos or extracts audio using [`yt-dlp`](https://github.com/yt-dlp/yt-dlp).

It walks you through:
- finding `yt-dlp`
- choosing a format
- choosing a video quality
- selecting an output folder
- downloading the media directly from the URL you provide

---

## Features

- Download videos as **MP4**
- Extract audio as **MP3**
- Automatically searches for `yt-dlp.exe`
- Can offer to install `yt-dlp` with `winget`
- Lets you choose:
  - output format
  - quality preset
  - download folder
- Shows `yt-dlp` output in the console while downloading

---

## Requirements

- **Windows**
- **.NET 10.0**
- [`yt-dlp`](https://github.com/yt-dlp/yt-dlp)
- `winget` if you want automatic installation support

---

## How it works

When you start the app:

1. It tries to locate `yt-dlp.exe` on your PC.
2. If it cannot find it, it asks whether you want to install it using `winget`.
3. If you decline automatic installation, you can manually enter the path to `yt-dlp.exe`.
4. The app asks for the video URL.
5. You choose the output format:
   - `mp4`
   - `mp3`
6. If you choose `mp4`, you select a quality preset.
7. You enter the absolute folder path where the downloaded file should be saved.
8. The app runs `yt-dlp` with the selected options.

---

## Quick Start

### 1. Clone the repository
```

bash git clone <your-repo-url> cd Downloader
``` 

### 2. Build the project
```

bash dotnet build
``` 

### 3. Run the app
```

bash dotnet run
``` 

---

## Usage

After launching the app, follow the prompts in the console.

### Example flow
```

text Hello from Video downloader Video URL:
Please select the video format you want to download (1). mp4 (2). mp3
Please chose the number of the quality you want to download: (1). 4k(2160p) (2). 1440p (3). 1080p (4). 720p (5). 480p (6). 360p (7). best quality possible
Please enter the ABSOLUTE path to the folder where you want to download the video:
``` 

---

## Supported download modes

### MP4 video download

If you choose MP4, the app downloads the best matching video and audio streams and merges them into an MP4 file.

Quality presets map like this:

- `1` → `2160p`
- `2` → `1440p`
- `3` → `1080p`
- `4` → `720p`
- `5` → `480p`
- `6` → `360p`
- `7` → best available quality

### MP3 audio extraction

If you choose MP3, the app extracts audio and converts it to MP3.

---

## Output path

You must provide an **absolute folder path**.

The app automatically adds a filename template so files are saved using the video title:
```

text %(title)s.%(ext)s
``` 

That means the final filename is generated automatically by `yt-dlp`.

---

## Automatic `yt-dlp` detection

The app tries to find `yt-dlp.exe` on Windows using the system path.

If it is not found, the app will ask:

- whether you want to install it automatically with `winget`
- or whether you want to manually provide the path

If installation fails, you may need to install `yt-dlp` manually.

---

## Example manual `yt-dlp` install

If you want to install `yt-dlp` yourself, you can use one of the following approaches:

### Using winget
```

bash winget install yt-dlp
``` 

### Manual download

Download the executable from the official project page and make sure it is available on your system path or note its full path for the app.

---

## Project structure

- `Program.cs`  
  Main application flow, user prompts, and download process execution

- `YtDlpFinder.cs`  
  Finds `yt-dlp` or offers to install it

- `PreDownloadOptions.cs`  
  Handles format selection, quality selection, and output path input

---

## Notes

- This project is designed for **Windows** and depends on Windows-specific commands like `where` and `winget`.
- Input validation is intentionally simple, so entering invalid paths or unsupported values may cause issues.
- The app streams `yt-dlp` output and errors straight into the console.

---

## Limitations

- The current UI is console-based
- Format support is focused on:
  - MP4
  - MP3
- Error handling is basic
- Cross-platform support is not included yet

---

## Future improvements

Possible improvements for later:

- Better input validation
- Cross-platform support
- GUI version
- More format options
- Better progress display
- More robust error handling
- Saved settings / defaults

---

## Troubleshooting

### `yt-dlp not found`
- Make sure `yt-dlp.exe` is installed
- Add it to your PATH
- Or manually enter the full path when prompted

### `winget` installation fails
- Install `yt-dlp` manually
- Then rerun the app
- Or provide the path when prompted

### Download fails
- Check that the URL is valid
- Check that the output folder exists
- Make sure the folder path is absolute
- Make sure you have permission to write to that folder

---

## Disclaimer

Use this tool responsibly and make sure you comply with the terms of service and copyright rules of the platform or content you are downloading from.

---

## License

No license has been added yet.

---

AI is used only for this readme.md
