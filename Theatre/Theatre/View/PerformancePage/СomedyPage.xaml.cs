using System;
using Theatre.Model;
using Theatre.ViewModel;
using Xamarin.Forms;
using Platform = Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Theatre.View.PerformancePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class СomedyPage : ContentPage
    {
        public СomedyPage()
        {
            InitializeComponent();
            ComedyLV.On<Platform::Android>().SetIsFastScrollEnabled(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as ComedyListViewModel)?.Init(Navigation);
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (BindingContext as ComedyListViewModel).GoToDetail((Performance)e.Item);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime t = DataSelected.Date;
            string date = String.Format("{0:dd-MM-yyyy}", t);
            (BindingContext as ComedyListViewModel).DateSelected(date);
        }

        private void Calendar_OnClicked(object sender, EventArgs e)
        {
            IsEnabled = true;
            DataSelected.Focus();
        }
    }
}