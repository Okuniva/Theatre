using System.Diagnostics;
using Plugin.Settings;
using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View.PerformancePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DramaPage : ContentPage
    {
        public DramaPage()
        {
            InitializeComponent();
            (BindingContext as DramaListViewModel)?.Init();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}