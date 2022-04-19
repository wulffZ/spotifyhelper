using System.Configuration;
using System.Diagnostics;
using System.Net;

namespace SpotifyHelper;

public class Thumbnail
{
    private string workingDir;
    private string url;
    private string watchCode;
    private string fileName;

    public Thumbnail(string workingDir, string url, string fileName)
    {
        this.watchCode = url.Substring(url.LastIndexOf('=') + 1);
        this.workingDir = workingDir;
        this.url = $"https://i.ytimg.com/vi/{watchCode}/maxresdefault.jpg";
        this.fileName = fileName;
    }
    
    public void Download()
    {
        using (WebClient client = new WebClient()) 
        {
            try
            {
                client.DownloadFile(new Uri(url), workingDir + fileName + ".jpg");
            }
            catch (WebException)
            {
                this.url = $"https://i.ytimg.com/vi/{watchCode}/hqdefault.jpg";
                client.DownloadFile(new Uri(url), workingDir + fileName + ".jpg");
            }
            
        }
    }

    public void AddThumbnail()
    {
        string arguments = $" -i \"{workingDir + fileName}.mp3\" -i \"{workingDir + fileName}.jpg\" -c copy -map 0 -map 1 -metadata:s:v title=\"Album cover\" -metadata:s:v comment=\"Cover (Front)\" \"{workingDir + fileName}_processed.mp3\"";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = SpotifyHelperApp.ffmpegExeLocation,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = workingDir
            }
        };
        
        Console.WriteLine("Adding album cover...");

        process.Start();
        process.WaitForExit();
        
        CleanUp();
    }

    private void CleanUp()
    {
        File.Delete(workingDir + fileName + ".mp3");   
        File.Delete(workingDir + fileName + ".jpg");        
    }
}