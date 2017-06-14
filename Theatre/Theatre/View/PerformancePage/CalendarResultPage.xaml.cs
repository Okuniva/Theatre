using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Model;
using Theatre.ViewModel;
using Xamarin.Forms;
using Platform = Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Theatre.View.PerformancePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarResultPage : ContentPage
    {
        public CalendarResultPage(CalendarResultListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.Navigation = Navigation;
            PerformanceLV.On<Platform::Android>().SetIsFastScrollEnabled(true);
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (BindingContext as CalendarResultListViewModel).GoToDetail((Performance)e.Item);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }
    }
}