using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Model;
using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailHomePage : ContentPage
    {
        public DetailHomePage(DetailHomeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.Navigation = Navigation;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (BindingContext as DetailHomeViewModel).GoToDetail((Poster)e.Item);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }
    }
}