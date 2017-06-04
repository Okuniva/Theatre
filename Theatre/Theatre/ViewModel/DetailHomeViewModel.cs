using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Theatre.Model;
using Theatre.Services;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class DetailHomeViewModel
    { 
        public List<Poster> Posters { get; set; }
        public Performance Performance { get; set; }
        internal INavigation Navigation { get; set; }

        public DetailHomeViewModel(Performance performance)
        {
            Performance = performance;
            Posters = performance.posters.ToList();
        }
    }
}

