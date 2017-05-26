using Theatre.Services;

namespace Theatre.ViewModel
{
    public class ViewModelLocator
    {
        public PerformanceListViewModel PerformanceListVM { get; set; }

        public ViewModelLocator()
        {
            var dbServiceToUse = new RealmDBService();
            PerformanceListVM = new PerformanceListViewModel(dbServiceToUse);
        }
    }
}