using System;
using WaterTracker.Services;
using WaterTracker.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Properties.TryGetValue("watergol",out object watergol)
                && watergol is Int32)
            {
                MainPage = new MainPage();
            } else
            {
                MainPage = new EditDalyDrinkPageView(isFirstLoad:true);
            }           
        }

        internal readonly IMangaer DataBase = new DatabaseMangaer();
    }
}
