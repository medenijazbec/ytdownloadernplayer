using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using Xamarin.Forms;
using Plugin.DownloadManager;
using SQLite;



namespace ProjektDownloadMp3mp4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //VideoClass video = new VideoClass();


        }

        private void downloadMP4Button_Clicked(object sender, EventArgs e)
        {
                string videoLink = Link.Text;
                //string link = "https://www.youtube.com/watch?v=wuJIqmha2Hk";         
                var youTube = YouTube.Default; // starting point for YouTube actions
                var video = youTube.GetVideo(videoLink); // gets a Video object with info about the video
                File.WriteAllBytes(@"C:\" + video.FullName, video.GetBytes());//no permission exception????????? download manager? manifest=yes


            //struct for data 

            string videoName = video.FullName;

            UserHistoryClass theHistory = new UserHistoryClass(videoName, videoLink);

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserHistoryClass>();
                conn.Insert(theHistory);

                //int rowsAdded = conn.Insert(theHistory);
                //conn.Close();
            
            }
            
         


         
        }

        private void downloadMP3Button_Clicked(object sender, EventArgs e)
        {
            string videoLink = Link.Text;
            //string link = "https://www.youtube.com/watch?v=wuJIqmha2Hk";         
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(videoLink); // gets a Video object with info about the video
            


            //struct for data 

            string videoName = video.FullName;

            UserHistoryClass theHistory = new UserHistoryClass(videoName, videoLink);

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserHistoryClass>();
                conn.Insert(theHistory);
                
                //int rowsAdded = conn.Insert(theHistory);
                //conn.Close();




            }
            //very nice
            File.WriteAllBytes(App.FilePath + video.FullName, video.GetBytes());//no permission exception????????? download manager? manifest=yes




        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            
        }

        private void historyButton_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new historyPage();


        }
    }
}
