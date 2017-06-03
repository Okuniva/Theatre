using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Connectivity;
using Plugin.Settings;
using Rg.Plugins.Popup.Services;
using Theatre.Services;
using Theatre.View;
using Theatre.View.PerformancePage;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class LoadingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand => new Command(Init);
        //private INavigation _navigation;
        //private Task _LoadJsonTask = null;
        protected IDBService DBService;
        private States _state = States.Loading;
        public enum States
        {
            Loading,
            Normal,
            Error,
            NoInternet,
            NoData
        }

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

            if (!CrossConnectivity.Current.IsConnected)
            {
                State = States.NoInternet;
                return;
            }
            else
            {
                //if (_LoadJsonTask != null)
                //{
                //    Debug.WriteLine("done");
                //}
                //else
                //{
                //Debug.WriteLine("process");

                //_LoadJsonTask = new LoadServices().ResetAllData(DBService);

                //_LoadJsonTask.ContinueWith((t) =>
                //{
                //    Debug.WriteLine("done");
                //    State = States.Normal;
                //    _LoadJsonTask = null;
                //}, TaskScheduler.FromCurrentSynchronizationContext());
                //}
            }
        }

        public void Init()
        {
        }
    }
}