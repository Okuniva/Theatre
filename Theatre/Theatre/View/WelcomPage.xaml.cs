using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.View.PerformancePage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomPage : ContentPage
    {
        public WelcomPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            //video.OnFinishedPlaying = () => { Debug.WriteLine("Video Finished"); };
            //Navigation.InsertPageBefore(new SwipeLeftMenuPage(), this);
            //await Navigation.PopAsync().ConfigureAwait(false);
            await Navigation.PushModalAsync(new SwipeLeftMenuPage());
            //Navigation.RemovePage(WelcomPage);
        }

        protected override void OnDisappearing()
        {
            //Navigation.RemovePage(this);
        }
    }
}