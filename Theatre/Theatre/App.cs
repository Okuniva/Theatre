using Theatre.View;
using Theatre.View.PerformancePage;
using Theatre.ViewModel;
using Xamarin.Forms;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace Theatre
{
    public class App : Application
    {
        public static ViewModelLocator VMLocator = new ViewModelLocator();

        public App()
        {
            //if ("1" == CrossSettings.Current.GetValueOrDefault<string>("timestamp", "1"))
            //{
            //    MainPage = new NavigationPage(new View.WelcomPage());
            //}
            //else
            //{
            MainPage = new SwipeLeftMenuPage();
            //MainPage = new DramaPage();
            //}
        }

        protected override void OnStart()
        {
            MobileCenter.Start("ios=edf2bf0f-f04d-4195-8e38-8399070e8604;" +
                               "uwp={Your UWP App secret here};" +
                               "android={Your Android App secret here}",
                typeof(Analytics), typeof(Crashes));
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
