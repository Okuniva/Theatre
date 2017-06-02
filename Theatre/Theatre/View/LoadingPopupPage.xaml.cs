using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Theatre.Services;
using Theatre.View.PerformancePage;
using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPopupPage : PopupPage
    {
        private Task _LoadJsonTask = null;

        public LoadingPopupPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //_LoadJsonTask = new LoadServices().ResetAllData(new RealmDBService());

            //_LoadJsonTask.ContinueWith((t) =>
            //{
            //    Debug.WriteLine("done");
            //    _LoadJsonTask = null;
            //}, TaskScheduler.FromCurrentSynchronizationContext());
            //await Navigation.PushAsync(new HomePage());

        }
    }
}