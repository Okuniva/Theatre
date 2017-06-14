using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Theatre.Model;
using Theatre.Services;
using Theatre.View;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class CalendarResultListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<Performance> _performances;

        public ObservableCollection<Performance> Performances
        {
            get => _performances;
            set
            {
                _performances = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Performances"));
            }
        }

        public INavigation Navigation { get; set; }

        public ICommand GoToDetailCommand { get; private set; }

        protected IDBService DBService = new RealmDBService();

        private string _date;

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                Performances = new ObservableCollection<Performance>(DBService.GetPerformancesByDate(_date));
            }
        }

        public CalendarResultListViewModel(string date)
        {
            Date = date;
        }

        internal void GoToDetail(Performance performance)
        {
            var page = new DetailHomePage(new DetailHomeViewModel(performance));

            Navigation.PushAsync(page, true);
        }
    }
}