using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Theatre.Model;
using Theatre.Services;
using Theatre.View;
using Theatre.View.PerformancePage;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class OtherListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Performance> _other;

        public ObservableCollection<Performance> Other
        {
            get => _other;
            set
            {
                _other = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Other"));
            }
        }

        public INavigation Navigation { get; set; }

        public ICommand GoToDetailCommand { get; private set; }

        protected IDBService DBService;

        private bool _isRefreshing = false;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsRefreshing"));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await new LoadServices().RefreshPerformance(DBService);

                    IsRefreshing = false;
                });
            }
        }

        public OtherListViewModel(IDBService dbService)
        {
            DBService = dbService;

            GoToDetailCommand = new Command<Performance>(GoToDetail);

            Init();
        }

        public void Init(INavigation navigation)
        {
            Navigation = navigation;
            Other = new ObservableCollection<Performance>(DBService.GetPerformancesByType(6));
        }

        public void Init()
        {
            Other = new ObservableCollection<Performance>(DBService.GetPerformancesByType(6));
        }

        internal void GoToDetail(Performance performance)
        {
            var page = new DetailHomePage(new DetailHomeViewModel(performance));

            Navigation.PushAsync(page, true);
        }

        internal void DateSelected(string date)
        {
            var page = new CalendarResultPage(new CalendarResultListViewModel(date));

            Navigation.PushAsync(page, true);
        }
    }
}