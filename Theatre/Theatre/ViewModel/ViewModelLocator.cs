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
        public ComedyListViewModel ComedyListVM { get; set; }
        public MelodramaListViewModel MelodramaListVM { get; set; }
        public TragicomedyListViewModel TragicomedyListVM { get; set; }
        public DreamListViewModel DreamListVM { get; set; }
        public OtherListViewModel OtherListVM { get; set; }
        public TicketsListViewViewModel TicketsListVM { get; set; }
        public ArticleListViewModel ArticleListVM { get; set; }
        //public OperaListViewModel OperaListVM { get; set; }

        public ViewModelLocator()
        {
            IDBService dbServiceToUse = new RealmDBService();

            if (CrossConnectivity.Current.IsConnected) new LoadServices().ResetAllData(dbServiceToUse);

            DramaListVM = new DramaListViewModel(dbServiceToUse);
            ComedyListVM = new ComedyListViewModel(dbServiceToUse);
            MelodramaListVM = new MelodramaListViewModel(dbServiceToUse);
            TragicomedyListVM = new TragicomedyListViewModel(dbServiceToUse);
            DreamListVM = new DreamListViewModel(dbServiceToUse);
            OtherListVM = new OtherListViewModel(dbServiceToUse);
            TicketsListVM = new TicketsListViewViewModel(dbServiceToUse);
            ArticleListVM = new ArticleListViewModel(dbServiceToUse);
            //OperaListVM = new OperaListViewModel(dbServiceToUse);
        }
    }
}