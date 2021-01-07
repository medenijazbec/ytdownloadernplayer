﻿namespace ProjektDownloadMp3mp4
{
    public partial class App
    {
        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public App(string filePath)
        {
            InitializeComponent();
            MainPage = new MainPage();
            FilePath = filePath;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
