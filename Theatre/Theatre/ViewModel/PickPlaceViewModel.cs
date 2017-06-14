using System.ComponentModel;
using Theatre.Model;
using Theatre.Services;
using Theatre.View;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class PickPlaceViewModel
    {
        internal INavigation Navigation { get; set; }
        public Poster Poster { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string img { get; set; }

        public PickPlaceViewModel(Poster poster, Performance performance)
        {
            Poster = poster;
            id = poster.id;
            date = poster.date;
            name = performance.name;
            img = performance.img;
        }

        internal async void GoToDetail(string place)
        {
            await new LoadServices().PdfTicketLoad(id, name, img, place, date, new RealmDBService());

            var page = new SwipeLeftMenuPage();

            await Navigation.PushModalAsync(page, true);
        }
    }
}