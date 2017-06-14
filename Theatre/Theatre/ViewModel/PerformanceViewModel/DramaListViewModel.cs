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
    public class DramaListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Performance> _drama;

        public ObservableCollection<Performance> Drama
        {
            get => _drama;
            set
            {
                _drama = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Drama"));
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

        public DramaListViewModel(IDBService dbService)
        {
            DBService = dbService;

            GoToDetailCommand = new Command<Performance>(GoToDetail);

            Init();
        }

        public void Init(INavigation navigation)
        {
            Navigation = navigation;
            Drama = new ObservableCollection<Performance>(DBService.GetPerformancesByType(1));
        }

        public void Init()
        {
            Drama = new ObservableCollection<Performance>(DBService.GetPerformancesByType(1));
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