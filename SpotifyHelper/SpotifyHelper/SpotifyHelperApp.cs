namespace SpotifyHelper
{
    class SpotifyHelperApp
    {
        private static string fileName = $@"{Guid.NewGuid()}";
        
        public static void Main(string[] args)
        {
            string video_path = downloadFromUrl("https://www.youtube.com/watch?v=hVqrW-fPOQ0");
            string audio_path = convertFromPath(video_path);
            
            Console.WriteLine(audio_path);
        }

        public static string downloadFromUrl(string url)
        {
            Downloader _downloader = new Downloader();
            return _downloader.downloadFromUrl(url, fileName);
        }

        public static string convertFromPath(string videoPath)
        {
            Converter _converter = new Converter();
            _converter.convertFromPath(videoPath, fileName);

            return "";
        }
    }
}