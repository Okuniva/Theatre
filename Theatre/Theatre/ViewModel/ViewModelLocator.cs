using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Settings;
using Theatre.Services;

namespace Theatre.ViewModel
{
    public class ViewModelLocator
    {
        public DramaListViewModel DramaListVM { get; set; }
        public DreamListViewModel DreamListVM { get; set; }
        public OperaListViewModel OperaListVM { get; set; }
        public ComedyListViewModel ComedyListVM { get; set; }
        //public DramaListViewModel ArticleListVM { get; set; }
        //public DramaListViewModel TheatresListVM { get; set; }
        //public DramaListViewModel TicketListVM { get; set; }

        public ViewModelLocator()
        {
            var dbServiceToUse = new RealmDBService();
           

            DramaListVM = new DramaListViewModel(dbServiceToUse);
            DreamListVM = new DreamListViewModel(dbServiceToUse);
            OperaListVM = new OperaListViewModel(dbServiceToUse);
            ComedyListVM = new ComedyListViewModel(dbServiceToUse);
        }
    }
}