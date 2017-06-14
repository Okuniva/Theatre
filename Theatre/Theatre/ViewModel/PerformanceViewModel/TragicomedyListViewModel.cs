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
    public class TragicomedyListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Performance> _tragicomedy;

        public ObservableCollection<Performance> Tragicomedy
        {
            get => _tragicomedy;
            set
            {
                _tragicomedy = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Tragicomedy"));
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

        public TragicomedyListViewModel(IDBService dbService)
        {
            DBService = dbService;

            GoToDetailCommand = new Command<Performance>(GoToDetail);

            Init();
        }

        public void Init(INavigation navigation)
        {
            Navigation = navigation;
            Tragicomedy = new ObservableCollection<Performance>(DBService.GetPerformancesByType(4));
        }

        public void Init()
        {
            Tragicomedy = new ObservableCollection<Performance>(DBService.GetPerformancesByType(4));
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