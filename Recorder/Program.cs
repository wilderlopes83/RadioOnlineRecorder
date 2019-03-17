using System;
using System.IO;
using System.Reflection;

namespace Recorder
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            //var libDirectory =  new DirectoryInfo(Path.Combine("/usr/lib", "libvlc"));
            //var libDirectory =  new DirectoryInfo("/usr/lib/x86_64-linux-gnu");
            //var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", "x86_64-linux-gnu"));

            var destination = Path.Combine(currentDirectory, "record.ts");

            using (var mediaPlayer = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory))
            {

                var mediaOptions = new[]
                {
                    ":sout=#file{dst=" + destination + "}",
                    ":sout-keep"
                };

                mediaPlayer.SetMedia(new Uri("https://20833.live.streamtheworld.com/RADIOCIDADEAAC.aac"),
                    mediaOptions);

                mediaPlayer.Play();

                Console.WriteLine($"Recording in {destination}");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
