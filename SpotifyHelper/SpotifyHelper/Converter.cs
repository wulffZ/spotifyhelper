using System.Diagnostics;

namespace SpotifyHelper;

public class Converter
{
    private static string tmp = Path.GetTempPath();
    
    public void convertFromPath(string inputPath, string fileName)
    {
        fileName += ".aac";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = "-i " + inputPath + " -vn -acodec copy " + fileName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = tmp
            }
        };

        process.Start();
        process.WaitForExit();

    }
}