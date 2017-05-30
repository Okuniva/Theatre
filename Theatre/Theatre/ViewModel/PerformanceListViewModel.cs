using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Theatre.Model;
using Theatre.Services;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class PerformanceListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ICommand LoadDataCommand { protected set; get; }

        public enum States
        {
            Loading,
            Normal
        }

        private States _state;

        public States State
        {
            get => _state;
            set
            {
                _state = value;
                PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        } 

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

        protected IDBService DBService = new RealmDBService();

        //1 - Drama
        //2 - Commedia
        //3 - Opera
        //4 - Dream
        public PerformanceListViewModel(int type)
        {
            State = States.Loading;
            if (type == 1)
            {
                object timestamp = "";
                if (!App.Current.Properties.TryGetValue("timestamp", out timestamp))
                {
                    App.Current.Properties.Add("timestamp", "0");
                }
                new LoadPerfomancesServices().SetPerfomances(DBService);
            }
            Init(type);
            State = States.Normal;
        }

        public void Init(int type)
        {
            Performance = new List<Performance>(DBService.GetPerformancesByType(type));
        }
    }
}