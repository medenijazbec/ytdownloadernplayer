using System.IO;
using Android.OS;
using ProjektDownloadMp3mp4.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileDownloader))]

namespace ProjektDownloadMp3mp4.Droid
{
    public class FileDownloader : IDownloader
    {
        public void WriteDownloadedFile(byte[] bytes)
        {
            var dir = Environment.ExternalStorageDirectory?.AbsolutePath;
            WriteDownloadedFile(bytes, dir);
        }

        public void WriteDownloadedFile(byte[] bytes, string dir)
        {
            File.WriteAllBytes(dir, bytes);
        }
    }
}
