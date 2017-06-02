using System.Collections.ObjectModel;
using System.ComponentModel;
using Plugin.Settings;
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
                OnPropertyChanged("Opera");
            }
        }

        protected IDBService DBService;

        public DramaListViewModel(IDBService dbService)
        {
            DBService = dbService;

            //if ("1" == CrossSettings.Current.GetValueOrDefault<string>("timestamp", "1"))
            //{
            //    CrossSettings.Current.AddOrUpdateValue<string>("timestamp", "0");
            //    Reset();
            //}
            //else
            //{
            Init();
            //}
        }

        //1 - Opera
        //2 - Comedy
        //3 - Opera
        //4 - Dream
        public void Init()
        {
            Drama = new ObservableCollection<Performance>(DBService.GetPerformancesByType(1));
        }

        public async void Reset()
        {
            //Drama = await new LoadServices().ResetAllData(DBService);
        }
    }
}