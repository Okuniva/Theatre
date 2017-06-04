using Theatre.ViewModel;
using Xamarin.Forms;

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
            MainPage = new View.SwipeLeftMenuPage();
            //}
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
