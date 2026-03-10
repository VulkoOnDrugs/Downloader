using System.Diagnostics;

namespace Downloader;

public class PreDownloadOptions
{
    public static string VideoFormat()
    {
        string videoFormatOptions = "";
        bool chooseingFormat = true;
        
        Console.WriteLine("Please select the video format you want to download");
        
        while (chooseingFormat)
        {
           Console.WriteLine("(1). mp4");
           Console.WriteLine("(2). mp3"); // add -x --audio-format flags for audio only
           // Console.WriteLine("(3). webm");
           // Console.WriteLine("(4). avi");
           // Console.WriteLine("(5). mkv");
           Console.WriteLine("Please input the number of the format you want to download:");
           // int formatNumber = int.Parse(Console.ReadLine());
           if (!int.TryParse(Console.ReadLine(), out int formatNumber))
           {
               Console.WriteLine("Please enter a valid number");
               continue;
           }
           
           if (formatNumber == 1){videoFormatOptions = "mp4"; chooseingFormat = false;}
           else if (formatNumber == 2){videoFormatOptions = "mp3"; chooseingFormat = false;}
           else if (formatNumber == 3){videoFormatOptions = "webm"; chooseingFormat = false;}
           else if (formatNumber == 4){videoFormatOptions = "avi"; chooseingFormat = false;}
           else if (formatNumber == 5){videoFormatOptions = "mkv"; chooseingFormat = false;}
           else{
               Console.WriteLine("Please input the number of the format you want to download:");
           } 
        }
        
        
        return videoFormatOptions;
    }

    // public static string VideoQuality(string ytDlpPath,string ytVideoUrl)
    // {
    //     string videoQualityOptions = null; //return
    //     string processStartInfoArgs =  ytDlpPath + " --list-formats " + ytVideoUrl;
    //     // string processStartInfoArgs = "yt-dlp --list-formats " + ytVideoUrl;
    //     ProcessStartInfo videoQualityFetchProcessInfo = new ProcessStartInfo
    //     {
    //         FileName = "cmd.exe",
    //         Arguments = "/c " + processStartInfoArgs,
    //         RedirectStandardOutput = true,
    //         RedirectStandardError = true,
    //         UseShellExecute = false,
    //         CreateNoWindow = true
    //     };
    //     Process videoQualityFetchProcess = Process.Start(videoQualityFetchProcessInfo);
    //     string videoQualityFetchProcessOut = videoQualityFetchProcess.StandardOutput.ReadToEnd();
    //     videoQualityFetchProcess.WaitForExit();
    //     //add option for best video audio -f "bv*+ba/b"
    //     //add note for mp4 above 720p requires merging aka ffmpeg
    //
    //     if (videoQualityOptions == null)
    //     {
    //         //chose anouther option
    //     }
    //     return videoQualityFetchProcessOut;
    // }

    public static int VideoQuality()
    {
        int videoQuality = 1080;
        
        Console.WriteLine("Please chose the number of the quality you want to download:");
        Console.WriteLine("(1). 4k(2160p)");
        Console.WriteLine("(2). 1440p");
        Console.WriteLine("(3). 1080p");
        Console.WriteLine("(4). 720p");
        Console.WriteLine("(5). 480p");
        Console.WriteLine("(6). 360p");
        Console.WriteLine("(7). best quality possible");
        bool chooseingQuality = true;
        while (chooseingQuality)
        {
            videoQuality = int.Parse(Console.ReadLine());
            if (videoQuality >= 8 || videoQuality <= 0)
            {
                Console.WriteLine("Please input a number between 1 and 7");
            }else
            {
                chooseingQuality = false;
            }
            
        }

        if (videoQuality == 1) {videoQuality=2160; }
        else if(videoQuality == 2){videoQuality=1440;}
        else if(videoQuality == 3){videoQuality=1080;}
        else if(videoQuality == 4){videoQuality=720;}
        else if(videoQuality == 5){videoQuality=480;}
        else if(videoQuality == 6){videoQuality=360;}
        else if(videoQuality == 7){videoQuality=1;}

        return videoQuality;
    }
    
    public static string downloadPath()
    {
        string downloadPath = "";
        Console.WriteLine("Please enter the ABSOLUTE path to the folder where you want to download the video:");
        downloadPath = Console.ReadLine();
        while (downloadPath == "")
        {
            Console.WriteLine("Please enter a valid download path:");
            downloadPath = Console.ReadLine();
        }

        downloadPath = downloadPath.Trim().Trim('"');
        downloadPath = $@"{downloadPath}\%(title)s.%(ext)s";
        return downloadPath;
    }
}