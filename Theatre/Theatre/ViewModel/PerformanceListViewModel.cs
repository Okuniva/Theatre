using System.Collections.Generic;
using System.ComponentModel;
using Theatre.Model;
using Theatre.Services;

namespace Theatre.ViewModel
{
    public class PerformanceListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private List<Performance> _performance;

        public List<Performance> Performance
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
                Performance = new List<Performance>(DBService.SearchPerformances(_searchText));
            }
        }

        protected IDBService DBService;

        //1 - Drama
        //2 - Commedia
        //3 - Opera
        //4 - Dream
        public PerformanceListViewModel(IDBService dbService, int type)
        {
            DBService = dbService;

            Init(type);
        }

        public void Init(int type)
        {
            Performance = new List<Performance>(DBService.GetPerformancesByType(type));
        }
    }
}