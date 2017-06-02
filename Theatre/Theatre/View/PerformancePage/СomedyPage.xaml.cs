using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View.PerformancePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class СomedyPage : ContentPage
    {
        public СomedyPage()
        {
            InitializeComponent();
            (BindingContext as ComedyListViewModel)?.Init();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}