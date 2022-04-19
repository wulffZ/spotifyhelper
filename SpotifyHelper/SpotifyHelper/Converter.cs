using System.Configuration;
using System.Diagnostics;

namespace SpotifyHelper;

public class Converter
{
    private string workinDir;
    private string fileName;

    public Converter(string workinDir, string fileName)
    {
        this.workinDir = workinDir;
        this.fileName = fileName;
    }

    public void Convert()
    {
        string arguments = $" -vn -sn -dn -i \"{workinDir + fileName}.mp4\" -codec:a libmp3lame -qscale:a 4 \"{workinDir + fileName}.mp3\"";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = SpotifyHelperApp.ffmpegExeLocation,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = workinDir
            }
        };
        
        Console.WriteLine("Converting to mp3...");

        process.Start();
        process.WaitForExit();

        CleanUp();
    }

    private void CleanUp()
    {
        File.Delete(workinDir + fileName + ".mp4");
    }
}