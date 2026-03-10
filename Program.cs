using System.Diagnostics;

namespace Downloader;

class Program
{
    static void Main(string[] args)
    {
        
        string ytDlpPath = YtDlpFinder.YtDlpPathFinder();
        
        Console.WriteLine("Hello from Video downloader");
        Console.WriteLine("Video URL:");
        string ytUrl = Console.ReadLine();
        // while (!ytUrl.Contains("youtube.com"))
        // {
        //     Console.WriteLine("Please enter a valid youtube video URL");
        //     ytUrl = Console.ReadLine();
        // }

        string videoFormat = PreDownloadOptions.VideoFormat();
        string outputPath = PreDownloadOptions.downloadPath();
        string argBuilder = "";
        int videoQuality = 0;
        if (videoFormat == "mp4")
        {
            videoQuality = PreDownloadOptions.VideoQuality();
                if (videoQuality == 1) // "best quality"
                {
                    argBuilder = $"-f \"bv*[ext=mp4]+ba[ext=m4a]/b[ext=mp4]/best\" --merge-output-format mp4 -o \"{outputPath}\" \"{ytUrl}\"";
                }
                else
                {
                    argBuilder = $"-f \"bv*[ext=mp4][height<={videoQuality}]+ba[ext=m4a]/b[ext=mp4][height<={videoQuality}]/b[ext=mp4]/best\" --merge-output-format mp4 -o \"{outputPath}\" \"{ytUrl}\"";
                }
        }
        else if (videoFormat == "mp3")
        {
            argBuilder = $"-x --audio-format mp3 -o \"{outputPath}\" \"{ytUrl}\"";
        }

        int exitCode = downloadingProcess(argBuilder, ytDlpPath);
        Console.WriteLine($"yt-dlp finished with exit code {exitCode}");
    }

    private static int downloadingProcess(string argBuilder, string ytDlpPath)
    {
        ProcessStartInfo videoDownloadProcessInfo = new ProcessStartInfo
        {
            FileName = ytDlpPath,
            Arguments = argBuilder,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process videoDownloadProcess = new Process();
        videoDownloadProcess.StartInfo = videoDownloadProcessInfo;

        videoDownloadProcess.OutputDataReceived += (_, e) =>
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        };

        videoDownloadProcess.ErrorDataReceived += (_, e) =>
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        };

        videoDownloadProcess.Start();
        videoDownloadProcess.BeginOutputReadLine();
        videoDownloadProcess.BeginErrorReadLine();
        videoDownloadProcess.WaitForExit();

        return videoDownloadProcess.ExitCode;
    }
}