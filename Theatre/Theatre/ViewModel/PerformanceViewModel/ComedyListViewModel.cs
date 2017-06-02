using System.Collections.ObjectModel;
using System.ComponentModel;
using Theatre.Model;
using Theatre.Services;

namespace Theatre.ViewModel
{
    public class ComedyListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<Performance> _comedy;

        public ObservableCollection<Performance> Comedy
        {
            get => _comedy;
            set
            {
                _comedy = value;
                OnPropertyChanged("Comedy");
            }
        }

        protected IDBService DBService;

        public ComedyListViewModel(IDBService dbService)
        {
            DBService = dbService;

            Init();
        }

        public void Init()
        {
            Comedy = new ObservableCollection<Performance>(DBService.GetPerformancesByType(2));
        }
    }
}