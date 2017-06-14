using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Theatre.Model;
using Theatre.Services;
using Theatre.View;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class OperaListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Performance> _opera;

        public ObservableCollection<Performance> Opera
        {
            get => _opera;
            set
            {
                _opera = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Opera"));
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

        public OperaListViewModel(IDBService dbService)
        {
            DBService = dbService;

            GoToDetailCommand = new Command<Performance>(GoToDetail);

            Init();
        }

        public void Init(INavigation navigation)
        {
            Navigation = navigation;
            Opera = new ObservableCollection<Performance>(DBService.GetPerformancesByType(3));
        }

        public void Init()
        {
            Opera = new ObservableCollection<Performance>(DBService.GetPerformancesByType(3));
        }

        internal void GoToDetail(Performance performance)
        {
            var page = new DetailHomePage(new DetailHomeViewModel(performance));

            Navigation.PushAsync(page, true);
        }
    }
}