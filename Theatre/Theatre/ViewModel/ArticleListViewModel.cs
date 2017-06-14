using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Theatre.Model;
using Theatre.Services;
using Theatre.View;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class ArticleListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<Article> _articles;

        public ObservableCollection<Article> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Other"));
            }
        }

        public INavigation Navigation { get; set; }

        public ICommand GoToDetailCommand { get; private set; }

        protected IDBService DBService;

        public ArticleListViewModel(IDBService dbService)
        {
            DBService = dbService;

            GoToDetailCommand = new Command<Performance>(GoToDetail);

            Init();
        }

        public void Init(INavigation navigation)
        {
            Navigation = navigation;
            Articles = new ObservableCollection<Article>(DBService.GetArticles());
        }

        public void Init()
        {
            Articles = new ObservableCollection<Article>(DBService.GetArticles());
        }

        internal void GoToDetail(Performance performance)
        {
            var page = new DetailHomePage(new DetailHomeViewModel(performance));

            Navigation.PushAsync(page, true);
        }

    }
}