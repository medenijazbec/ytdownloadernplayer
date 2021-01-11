namespace ProjektDownloadMp3mp4
{
    public interface IDownloader
    {
        void WriteDownloadedFile(byte[] bytes, string filename);
    }
}
