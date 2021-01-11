using System;
using System.ComponentModel;
using ProjektDownloadMp3mp4.Classess;
using SQLite;
using VideoLibrary;
using Xamarin.Forms;

namespace ProjektDownloadMp3mp4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        private readonly IDownloader _downloader = DependencyService.Get<IDownloader>();

        public MainPage()
        {
            InitializeComponent();
            //VideoClass video = new VideoClass();
        }

        private void downloadMP4Button_Clicked(object sender, EventArgs e)
        {
            var videoLink = Link.Text;
            //string link = "https://www.youtube.com/watch?v=wuJIqmha2Hk";
            var video = YouTube.Default.GetVideo(videoLink); // gets a Video object with info about the video
            var filename = video.Title + ".mp4";
            _downloader.WriteDownloadedFile(video.GetBytes(), filename);
            AddHistoryEntry(video.FullName, videoLink);
        }

        private void downloadMP3Button_Clicked(object sender, EventArgs e)
        {
            var videoLink = Link.Text;
            //string link = "https://www.youtube.com/watch?v=wuJIqmha2Hk";
            var video = YouTube.Default.GetVideo(videoLink); // gets a Video object with info about the video
            var filename = video.Title + ".mp3";
            _downloader.WriteDownloadedFile(video.GetBytes(), filename);
            AddHistoryEntry(video.FullName, videoLink);
        }

        private static void AddHistoryEntry(string videoName, string videoLink)
        {
            using (var con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<UserHistoryClass>();
                con.Insert(new UserHistoryClass(videoName, videoLink));
            }
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
        }

        private void historyButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HistoryPage();
        }
    }
}
