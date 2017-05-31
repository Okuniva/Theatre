using Theatre.Services;

namespace Theatre.ViewModel
{
    public class ViewModelLocator
    {
        public LoadingViewModel LoginVM { get; set; }
        public PerformanceListViewModel DramaListVM { get; set; }
        public PerformanceListViewModel DreamListVM { get; set; }
        public PerformanceListViewModel OperaListVM { get; set; }
        public PerformanceListViewModel ComedyListVM { get; set; }
        public PerformanceListViewModel ArticleListVM { get; set; }
        public PerformanceListViewModel TheatresListVM { get; set; }
        public PerformanceListViewModel TicketListVM { get; set; }

        public ViewModelLocator()
        {
            var dbServiceToUse = new RealmDBService();
            LoginVM = new LoadingViewModel(dbServiceToUse);
            DramaListVM = new PerformanceListViewModel(dbServiceToUse, 1);
        }
    }
}