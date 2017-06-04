using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Theatre.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Plugin.Settings;

namespace Theatre.Services
{
    public class LoadServices
    {
        private static readonly HttpClient _client = new HttpClient();

        public async void ResetAllData(IDBService dbService)
        {
            var jsonContens = await _client.GetStringAsync("http://api-theatre.herokuapp.com/utils/updates?stamp=" +
                                                           CrossSettings.Current.GetValueOrDefault<string>("timestamp",
                                                               "0"));
            var data = JsonConvert.DeserializeObject<RootObject>(jsonContens);

            dbService = new RealmDBService();
            foreach (var performance in data.response.performances)
            {
                var newPerformance = new Performance
                {
                    id = performance.id,
                    desc = performance.desc,
                    img = performance.img,
                    author = performance.author,
                    name = performance.name,
                    p_type_id = performance.p_type_id,
                    theatre_id = performance.theatre_id,
                    theatre_name = performance.theatre_name,
                    hall_name = performance.hall_name,
                    near = performance.near
                };

                //newPerformance.actors.AddRange(performance.actors);

                foreach (var poster in performance.posters)
                {
                    newPerformance.posters.Add(poster);
                }

                dbService.SavePerfomance(newPerformance);
            }

            //foreach (var article in data.articles)
            //{
            //    var newArticle = new Article
            //    {
            //        id = article.id,
            //        name = article.name,
            //        desc = article.desc,
            //        img = article.img,
            //        date = article.date,
            //        theatre_name = article.theatre_name
            //    };

            //    dbService.SaveArticle(newArticle);
            //}

            //foreach (var theatre in data.theatres)
            //{
            //    var newTheatre = new Model.Theatre
            //    {
            //        id = theatre.id,
            //        name = theatre.name,
            //        desc = theatre.desc,
            //        img = theatre.img,
            //        address = theatre.address
            //    };

            //    dbService.SaveTheatre(newTheatre);
            //}
            Debug.WriteLine(data.response.performances.Count);
            CrossSettings.Current.AddOrUpdateValue<string>("timestamp", data.response.timestamp);
        }
    }
}