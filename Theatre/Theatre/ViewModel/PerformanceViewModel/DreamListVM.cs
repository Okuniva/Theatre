using System.Collections.ObjectModel;
using System.ComponentModel;
using Theatre.Model;
using Theatre.Services;

namespace Theatre.ViewModel
{
    public class DreamListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<Performance> _dream;

        public ObservableCollection<Performance> Dream
        {
            get => _dream;
            set
            {
                _dream = value;
                OnPropertyChanged("Dream");
            }
        }

        protected IDBService DBService;

        public DreamListViewModel(IDBService dbService)
        {
            DBService = dbService;

            Init();
        }
        
        public void Init()
        {
            Dream = new ObservableCollection<Performance>(DBService.GetPerformancesByType(4));
        }
    }
}