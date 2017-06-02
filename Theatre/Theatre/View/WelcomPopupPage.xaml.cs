using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Theatre.View.PerformancePage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomPopupPage : PopupPage
    {
        private HomePage _homePage;

        public WelcomPopupPage()
        {
            InitializeComponent();

            _homePage = new HomePage();
        }


        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(_homePage, true);
        }
    }
}