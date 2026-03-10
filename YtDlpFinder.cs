using System.Diagnostics;

namespace Downloader;

public class YtDlpFinder
{
    public static string YtDlpPathFinder()
    {
        string ytDlpPath = "error";
        string winYtDlpFinderOut = WinYtDlpFinder();

        if (string.IsNullOrWhiteSpace(winYtDlpFinderOut))
        {
            ytDlpPath = "yt-dlp not found";
            Console.WriteLine(ytDlpPath);
            Console.WriteLine("Do you want to download yt-dlp using winget? (y/n)");
            string answer = Console.ReadLine().ToLower();
            
            if (answer == "y")
            {
                Console.WriteLine("Downloading yt-dlp using winget");
                string downloaderOutput = WinGetYtDlpDownloader();
                
                Console.WriteLine(downloaderOutput);
                string foundPath = WinYtDlpFinder();
                if (foundPath.Contains("yt-dlp.exe"))
                {
                    ytDlpPath = foundPath;
                }
                else
                {
                    Console.WriteLine("Install failed, please try again or install manually");
                    Environment.Exit(1);
                }

            }
            else if (answer == "n")
            {
                Console.WriteLine("Please install yt-dlp manually");
                Console.WriteLine("Please input the yt-dlp path:");
                Console.WriteLine("If you want to exit the program, type exit");
                string input = Console.ReadLine();//may not work
                if (input == "exit" || input == "" || input == null)
                {
                    Environment.Exit(0);
                }
                else
                {
                    ytDlpPath = input;
                }
            }
        }else if (winYtDlpFinderOut.Contains("yt-dlp.exe"))
        {
            ytDlpPath = winYtDlpFinderOut;
        }
        else
        {
            ytDlpPath = "yt-dlp not found an error has occured";
            Console.WriteLine(winYtDlpFinderOut);
        }

        return ytDlpPath;
    }

    private static string WinYtDlpFinder()
    {

        // string yt_dlp_path = "YT-DLP not found";

        ProcessStartInfo ytDlpFinder = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/c where yt-dlp.exe",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        Process winYtDlpFinder = Process.Start(ytDlpFinder);
        string ytDlpFindOut = winYtDlpFinder.StandardOutput.ReadToEnd().Trim();
        winYtDlpFinder.WaitForExit();
        
        return ytDlpFindOut;
    }

    private static string WinGetYtDlpDownloader()
    {
        
        ProcessStartInfo wingetYtDlpDownloaderProcessStartInfo = new ProcessStartInfo
        {
            FileName = "winget",
            Arguments = "install yt-dlp",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            UseShellExecute = false
        };
        Process wingetYtDlpDownloaderProcess = Process.Start(wingetYtDlpDownloaderProcessStartInfo);
        string wingetYtDlpDownloaderOutput = wingetYtDlpDownloaderProcess.StandardOutput.ReadToEnd();
        wingetYtDlpDownloaderProcess.WaitForExit();
        return wingetYtDlpDownloaderOutput;
    }
}