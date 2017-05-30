using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Theatre.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Theatre.ViewModel;

namespace Theatre.Services
{
    public class LoadPerfomancesServices
    {
        public async void SetPerfomances(IDBService dbService)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://api-theatre.herokuapp.com") };
            var jsonContens = await client.GetStringAsync("/utils/updates?stamp=" + App.Current.Properties["timestamp"]);
            var o = JObject.Parse(jsonContens);
            var performances = JsonConvert.DeserializeObject<List<Performance>>(o.SelectToken(@"$.response.performances").ToString());

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

                dbService.SavePerfomance(newPerformance);
            }
        }
    }
}