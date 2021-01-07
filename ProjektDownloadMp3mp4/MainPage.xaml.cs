using System;
using System.ComponentModel;
using System.IO;
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
        // fixme: replace this with a better x-platform solution
        private const string DownloadsFolder = "/storage/emulated/0/Downloads";

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
            File.WriteAllBytes(Path.Combine(DownloadsFolder, video.FullName), video.GetBytes()); //no permission exception????????? download manager? manifest=yes

            var videoName = video.FullName;
            var theHistory = new UserHistoryClass(videoName, videoLink);

            using (var conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserHistoryClass>();
                conn.Insert(theHistory);

                //int rowsAdded = conn.Insert(theHistory);
                //conn.Close();
            }
        }

        private void downloadMP3Button_Clicked(object sender, EventArgs e)
        {
            var videoLink = Link.Text;
            //string link = "https://www.youtube.com/watch?v=wuJIqmha2Hk";
            var video = YouTube.Default.GetVideo(videoLink); // gets a Video object with info about the video
            File.WriteAllBytes(Path.Combine(DownloadsFolder, video.FullName), video.GetBytes()); //no permission exception????????? download manager? manifest=yes

            var videoName = video.FullName;
            var theHistory = new UserHistoryClass(videoName, videoLink);

            using (var conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserHistoryClass>();
                conn.Insert(theHistory);

                //int rowsAdded = conn.Insert(theHistory);
                //conn.Close();
            }
            //very nice
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
