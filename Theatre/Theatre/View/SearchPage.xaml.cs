using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new SearchBarViewModel();
        }
    }
}