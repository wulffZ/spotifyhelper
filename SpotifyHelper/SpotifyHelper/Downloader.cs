using VideoLibrary;

namespace SpotifyHelper;

public class Downloader
{
    private static string tmp = Path.GetTempPath();

    public string downloadFromUrl(string videoUrl, string fileName)
    {
        fileName += ".mp4";
        
        var youtube = YouTube.Default;
        var vid = youtube.GetVideo(videoUrl);

        File.WriteAllBytes(tmp + fileName, vid.GetBytes());

        return tmp + fileName;
    }
}