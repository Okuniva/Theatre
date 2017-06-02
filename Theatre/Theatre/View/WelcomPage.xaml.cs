using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.View.PerformancePage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomPage : CarouselPage
    {
        public WelcomPage()
        {
            InitializeComponent();
        }

        private  void Button_OnClicked(object sender, EventArgs e)
        {
             Navigation.PushModalAsync(new SwipeLeftMenuPage(), true);
        }
    }
}