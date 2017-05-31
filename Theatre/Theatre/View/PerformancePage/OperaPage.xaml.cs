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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //BindingContext = new PerformanceListViewModel(3);
            //(BindingContext as PerformanceListViewModel)?.Init(3);
        }
    }
}