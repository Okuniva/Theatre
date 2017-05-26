using System.Diagnostics;
using System.Threading.Tasks;
using Theatre.Services;
using Theatre.ViewModel;
using Xamarin.Forms;

namespace Theatre.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as PerformanceListViewModel)?.Init();
        }
    }
}
