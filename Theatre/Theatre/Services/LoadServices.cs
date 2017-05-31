using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Theatre.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Theatre.Services
{
    public class LoadServices
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task SetPerfomances(IDBService dbService)
        {
            //HttpClient client = new HttpClient();
            var jsonContens =
            //await client.GetStringAsync("http://api-theatre.herokuapp.com/utils/updates?stamp=" +
            //                             App.Current.Properties["timestamp"]);
            await _client.GetStringAsync("http://api-theatre.herokuapp.com/utils/updates?stamp=0");
            var o = JObject.Parse(jsonContens);
            var performances =
                JsonConvert.DeserializeObject<List<Performance>>(o.SelectToken(@"$.response.performances").ToString());

            foreach (var performance in performances)
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
                Debug.WriteLine("AddNewPerf");
                dbService.SavePerfomance(newPerformance);
            }
        }

        public async Task<List<Performance>> GetPerfomances()
        {
            //HttpClient client = new HttpClient();
            var jsonContens =
                //await client.GetStringAsync("http://api-theatre.herokuapp.com/utils/updates?stamp=" +
                //                             App.Current.Properties["timestamp"]);
                await _client.GetStringAsync("http://api-theatre.herokuapp.com/utils/updates?stamp=0");
            var o = JObject.Parse(jsonContens);
            var performances =
                JsonConvert.DeserializeObject<List<Performance>>(o.SelectToken(@"$.response.performances").ToString());

            return performances;
        }

        public async Task ResetAllData(IDBService dbService)
        {
            var jsonContens = await _client.GetStringAsync("/utils/updates?stamp=0");
            var data = JsonConvert.DeserializeObject<Response>(jsonContens);
            
            foreach (var performance in data.performances)
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

            foreach (var article in data.articles)
            {
                var newArticle = new Article
                {
                    id = article.id,
                    name = article.name,
                    desc = article.desc,
                    img = article.img,
                    date = article.date,
                    theatre_name = article.theatre_name
                };

                dbService.SaveArticle(newArticle);
            }

            foreach (var theatre in data.theatres)
            {
                var newTheatre = new Model.Theatre
                {
                    id = theatre.id,
                    name = theatre.name,
                    desc = theatre.desc,
                    img = theatre.img,
                    address = theatre.address
                };

                dbService.SaveTheatre(newTheatre);
            }
            Debug.WriteLine(data.performances.Count);
            App.Current.Properties.Add("timestamp", data.timestamp);
        }
    }
}