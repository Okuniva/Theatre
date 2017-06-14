using Plugin.Settings;
using Theatre.View;
using Theatre.View.PerformancePage;
using Theatre.ViewModel;
using Xamarin.Forms;

namespace Theatre
{
    public class App : Application
    {
        public static ViewModelLocator VMLocator = new ViewModelLocator();

        public App()
        {
            if ("1" == CrossSettings.Current.GetValueOrDefault<string>("timestamp", "1"))
            {
                MainPage = new WelcomPage();
            }
            else
            {
                MainPage = new SwipeLeftMenuPage();
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
