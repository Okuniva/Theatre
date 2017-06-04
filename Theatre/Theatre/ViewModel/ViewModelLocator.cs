using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Settings;
using Realms;
using Theatre.Services;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class ViewModelLocator
    {
        public DramaListViewModel DramaListVM { get; set; }
        public DreamListViewModel DreamListVM { get; set; }
        public OperaListViewModel OperaListVM { get; set; }
        public ComedyListViewModel ComedyListVM { get; set; }

        public ViewModelLocator()
        {
            IDBService dbServiceToUse = new RealmDBService();

            if (CrossConnectivity.Current.IsConnected) new LoadServices().ResetAllData(dbServiceToUse);

            DramaListVM = new DramaListViewModel(dbServiceToUse);
            DreamListVM = new DreamListViewModel(dbServiceToUse);
            OperaListVM = new OperaListViewModel(dbServiceToUse);
            ComedyListVM = new ComedyListViewModel(dbServiceToUse);
        }
    }
}