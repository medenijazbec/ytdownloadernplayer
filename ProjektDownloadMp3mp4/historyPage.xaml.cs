using System;
using ProjektDownloadMp3mp4.Classess;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektDownloadMp3mp4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new MainPage();
            return base.OnBackButtonPressed();
        }

        private void mainPageButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserHistoryClass>();
                var theHistory = conn.Table<UserHistoryClass>().ToList();
                //conn.Close();
                historyListView.ItemsSource = theHistory;
            }
        }
    }
}
