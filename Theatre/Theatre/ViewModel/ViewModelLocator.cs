using Theatre.Services;

namespace Theatre.ViewModel
{
    public class ViewModelLocator
    {
        public LoadingViewModel LoginVM { get; set; }
        public PerformanceListViewModel DramaListVM { get; set; }

        public ViewModelLocator()
        {
            var dbServiceToUse = new RealmDBService();
            LoginVM = new LoadingViewModel(dbServiceToUse);
            DramaListVM = new PerformanceListViewModel(dbServiceToUse, 1);
        }
    }
}