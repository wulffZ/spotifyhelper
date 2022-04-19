using VideoLibrary;

namespace SpotifyHelper;

public class Downloader
{
    private string workinDir;
    private string url;

    public Downloader(string workinDir, string url)
    {
        this.workinDir = workinDir;
        this.url = url;
    }

    public string Download()
    {
        var youtube = YouTube.Default;
        var vid = youtube.GetVideo(url);

        Console.WriteLine("Downloading from youtube...");

        File.WriteAllBytes(workinDir + vid.Title + ".mp4", vid.GetBytes());

        return vid.Title;
    }
}