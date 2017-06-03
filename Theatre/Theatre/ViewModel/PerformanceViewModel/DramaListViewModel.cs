using System.Collections.ObjectModel;
using System.ComponentModel;
using Theatre.Model;
using Theatre.Services;

namespace Theatre.ViewModel
{
    public class DramaListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<Performance> _drama;

        public ObservableCollection<Performance> Drama
        {
            get => _drama;
            set
            {
                _drama = value;
                OnPropertyChanged("Drama");
            }
        }

        protected IDBService DBService;

        public DramaListViewModel(IDBService dbService)
        {
            DBService = dbService;

            Init();
        }

        public void Init()
        {
            Drama = new ObservableCollection<Performance>(DBService.GetPerformancesByType(1));
        }
    }
}