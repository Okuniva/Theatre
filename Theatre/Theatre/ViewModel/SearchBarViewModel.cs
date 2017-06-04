using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Theatre.Model;
using Theatre.Services;
using Theatre.View;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class SearchBarViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Performance> Performances { get; private set; }

        public INavigation Navigation { get; set; }

        public ICommand GoToDetailCommand { get; private set; }

        protected IDBService DBService = new RealmDBService();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchText"));
                Performances = new ObservableCollection<Performance>(DBService.SearchPerformances(_searchText));
            }
        }

        public SearchBarViewModel()
        {
            GoToDetailCommand = new Command<Performance>(GoToDetail);
        }

        internal void GoToDetail(Performance performance)
        {
            var page = new DetailHomePage(new DetailHomeViewModel(performance));

            Navigation.PushAsync(page, true);
        }
    }
}
