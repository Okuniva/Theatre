using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Theatre.Model;
using Theatre.Services;
using Theatre.View;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class TicketsListViewViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Ticket> _tickets;

        public ObservableCollection<Ticket> Tickets
        {
            get => _tickets;
            set
            {
                _tickets = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Tickets"));
            }
        }

        public INavigation Navigation { get; set; }

        public ICommand GoToDetailCommand { get; private set; }

        protected IDBService DBService;

        public TicketsListViewViewModel(IDBService dbService)
        {
            DBService = dbService;

            GoToDetailCommand = new Command<Ticket>(GoToDetail);

            Init();
        }

        public void Init(INavigation navigation)
        {
            Navigation = navigation;
            Tickets = new ObservableCollection<Ticket>(DBService.GetTickets());
        }

        public void Init()
        {
            Tickets = new ObservableCollection<Ticket>(DBService.GetTickets());
        }

        internal void GoToDetail(Ticket ticket)
        {
            //var page = new DetailHomePage(new DetailHomeViewModel(ticket));

            //Navigation.PushAsync(page, true);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}