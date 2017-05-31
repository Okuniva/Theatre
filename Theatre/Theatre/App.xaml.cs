using Theatre.ViewModel;
using Xamarin.Forms;

namespace Theatre
{
    public partial class App : Application
    {
        public static ViewModelLocator VMLocator = new ViewModelLocator();

        public App()
        {
            InitializeComponent();
            MainPage = new View.SwipeLeftMenuPage();
            //MainPage = new View.PerformancePage.DramaPage();
            //MainPage = new View.LoadingPage();
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
