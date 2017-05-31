using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Theatre.Services;
using Theatre.View.PerformancePage;

namespace Theatre.ViewModel
{
    public class LoadingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        public enum States
        {
            Loading,
            Normal
        }

        private Task _LoadJsonTask = null;
        private States _state;
        protected IDBService DBService;

        public States State
        {
            get => _state;
            set
            {
                _state = value;
                PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        public LoadingViewModel(IDBService dbService)
        {
            DBService = dbService;
            if (_LoadJsonTask != null)
            {
                State = States.Normal;
                Debug.WriteLine("done");
            }
            else
            {
                Debug.WriteLine("process");
                _LoadJsonTask =  new LoadServices().SetPerfomances(DBService);

                _LoadJsonTask.ContinueWith((t) =>
                {
                    Debug.WriteLine("done");
                    var reP = new DramaPage();
                    State = States.Normal;
                    _LoadJsonTask = null;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }

            Init();
        }

        public void Init()
        {
            State = States.Loading;
        }
    }
}