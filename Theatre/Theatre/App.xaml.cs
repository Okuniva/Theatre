using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Theatre.Services;
using Theatre.ViewModel;
using Xamarin.Forms;

namespace Theatre
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new View.SwipeLeftMenuPage();
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
