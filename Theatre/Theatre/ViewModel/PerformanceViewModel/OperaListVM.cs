using System.Collections.ObjectModel;
using System.ComponentModel;
using Theatre.Model;
using Theatre.Services;

namespace Theatre.ViewModel
{
    public class OperaListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<Performance> _opera;

        public ObservableCollection<Performance> Opera
        {
            get => _opera;
            set
            {
                _opera = value;
                OnPropertyChanged("Drama");
            }
        }

        protected IDBService DBService;

        public OperaListViewModel(IDBService dbService)
        {
            DBService = dbService;

            Init();
        }

        public void Init()
        {
            Opera = new ObservableCollection<Performance>(DBService.GetPerformancesByType(3));
        }
    }
}