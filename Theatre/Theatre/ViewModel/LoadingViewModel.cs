using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Theatre.Services;
using Theatre.View;
using Theatre.View.PerformancePage;

namespace Theatre.ViewModel
{
    public class LoadingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        private Task _LoadJsonTask = null;
        protected IDBService DBService;

        public LoadingViewModel(IDBService dbService)
        {
            DBService = dbService;

            Init();
        }

        public async void Init()
        {
            //var loadingPage = new LoadingPopupPage();
            //await PopupNavigation.PushAsync(loadingPage);
            //if (_LoadJsonTask != null)
            //{
            //    await PopupNavigation.RemovePageAsync(loadingPage);
            //    Debug.WriteLine("done");
            //}
            //else
            //{
            //    Debug.WriteLine("process");

            //await Task.Delay(2000);
            _LoadJsonTask = new LoadServices().ResetAllData(DBService);

            await _LoadJsonTask.ContinueWith((t) =>
             {
                 Debug.WriteLine("done");
                 _LoadJsonTask = null;
             }, TaskScheduler.FromCurrentSynchronizationContext());
            //}
            //await PopupNavigation.RemovePageAsync(loadingPage);
            //await Task.Delay(2000);
        }
    }
}