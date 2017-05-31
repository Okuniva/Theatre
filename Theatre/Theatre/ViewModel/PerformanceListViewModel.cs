using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Theatre.Model;
using Theatre.Services;

namespace Theatre.ViewModel
{
    public class PerformanceListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<Performance> _performance;

        public ObservableCollection<Performance> Performance
        {
            get => _performance;
            set
            {
                _performance = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Perfomance"));
            }
        }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchText"));
                Performance = new ObservableCollection<Performance>(DBService.SearchPerformances(_searchText));
            }
        }

        protected IDBService DBService;

        //1 - Drama
        //2 - Comedy
        //3 - Opera
        //4 - Dream
        public PerformanceListViewModel(IDBService dbService, int type)
        {
            DBService = dbService;

            Init(type);
        }

        public void Init(int type)
        {
            Performance = new ObservableCollection<Performance>(DBService.GetPerformancesByType(type));
            //var item = await new LoadServices().GetPerfomances();
            //Performance = null;
            //Performance = item;
        }
    }
}