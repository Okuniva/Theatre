using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Theatre.Model;
using Theatre.Services;
using Theatre.View;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class ComedyListViewModel
    {
        public ObservableCollection<Performance> Comedy { get; private set; }

        public INavigation Navigation { get; set; }

        public ICommand GoToDetailCommand { get; private set; }

        protected IDBService DBService;

        public ComedyListViewModel(IDBService dbService)
        {
            DBService = dbService;

            GoToDetailCommand = new Command<Performance>(GoToDetail);

            Init();
        }

        public void Init(INavigation navigation)
        {
            Navigation = navigation;
            Comedy = new ObservableCollection<Performance>(DBService.GetPerformancesByType(2));
        }

        public void Init()
        {
            Comedy = new ObservableCollection<Performance>(DBService.GetPerformancesByType(2));
        }
        
        internal void GoToDetail(Performance performance)
        {
            var page = new DetailHomePage(new DetailHomeViewModel(performance));

            Navigation.PushAsync(page);
        }
    }
}