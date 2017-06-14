using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Theatre.Services;
using Xamarin.Forms;

namespace Theatre.View.PerformancePage
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            //this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count]);

            //var existingPages = Navigation.NavigationStack.ToList();
            //foreach (var page in existingPages)
            //{
            //    Navigation.RemovePage(page);
            //}
        }
    }
}
