using System.Collections.Generic;
using System.Linq;
using Theatre.Model;
using Theatre.View;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class DetailHomeViewModel
    { 
        public List<Poster> Posters { get; set; }
        public Performance Performance { get; set; }
        public string Name { get; set; }
        internal INavigation Navigation { get; set; }

        public DetailHomeViewModel(Performance performance)
        {
            Performance = performance;
            Posters = performance.posters.ToList();
        }

        internal void GoToDetail(Poster poster)
        {
            var page = new PickPlacePage(new PickPlaceViewModel(poster, Performance));

            Navigation.PushAsync(page, true);
        }
    }
}

