using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View.PerformancePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OperaPage : ContentPage
    {
        public OperaPage()
        {
            InitializeComponent();
            (BindingContext as OperaListViewModel)?.Init();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}