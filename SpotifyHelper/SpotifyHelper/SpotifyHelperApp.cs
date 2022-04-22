using System.Configuration;
using System.Runtime.InteropServices;

namespace SpotifyHelper
{
    class SpotifyHelperApp
    {
        public static string? ffmpegExeLocation = ConfigurationManager.AppSettings.Get("FFMPEGExeLocation");
        private static string workinDir = Path.GetTempPath();
        private static string destinationDir;
        private static string fileName;
        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            string url = AskUrl();

            ValidateAppConfig();

            Downloader downloader = new Downloader(workinDir, url);
            fileName = downloader.Download();

            Converter converter = new Converter(workinDir, fileName);
            converter.Convert();
            
            Thumbnail thumbnail = new Thumbnail(workinDir, url, fileName);
            thumbnail.Download();
            thumbnail.AddThumbnail();

            MoveSong();

            Console.Write("Download & Convert again? (y/N)");
            string restart = Console.ReadLine();
            
            if (restart == "y")
            {
                Run();
            } else {
                Environment.Exit(1);
            }
        }

        private static string AskUrl()
        {
            Console.Write("Enter YouTube link:");
            string? url = Console.ReadLine();

            if (string.IsNullOrEmpty(url))
            {
                return AskUrl();
            }

            return url;
        }

        private static void ValidateAppConfig()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                destinationDir = ConfigurationManager.AppSettings.Get("DestinationDirPathLinux");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                destinationDir = ConfigurationManager.AppSettings.Get("DestinationDirPathWindows");
            }

            if (!Directory.Exists(destinationDir))
            {
                Console.WriteLine("Please configure your path," + destinationDir + " is not correct.");
                Environment.Exit(1);
            }
        }

        private static void MoveSong()
        {
            Console.Write("Moving file...");

            File.Move(workinDir + fileName + "_processed.mp3", destinationDir + fileName + ".mp3");
            
            Console.WriteLine("Moved file to destination folder. Exiting.");
        }
    }
}