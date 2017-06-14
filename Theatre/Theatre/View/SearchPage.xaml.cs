using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Model;
using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Platform = Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();

            PerformanceLV.On<Platform::Android>().SetIsFastScrollEnabled(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new SearchBarViewModel(Navigation);
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (BindingContext as SearchBarViewModel).GoToDetail((Performance)e.Item);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }
    }
}