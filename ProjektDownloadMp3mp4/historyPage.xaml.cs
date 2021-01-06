using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektDownloadMp3mp4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class historyPage : ContentPage
    {
        public historyPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage();
            return base.OnBackButtonPressed();
        }


        private void mainPageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserHistoryClass>();
                var theHistory = conn.Table<UserHistoryClass>().ToList();

                //conn.Close();

                historyListView.ItemsSource = theHistory;


            }


        }


    }
}