using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View.PerformancePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DreamPage : ContentPage
    {
        public DreamPage()
        {
            InitializeComponent();
            (BindingContext as DreamListViewModel)?.Init();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}