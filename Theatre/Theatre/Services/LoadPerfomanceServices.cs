using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Theatre.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Theatre.Services
{
    public class LoadPerfomanceServices
    {
        public async Task SetPerfomance()
        {
            var client = new HttpClient { BaseAddress = new Uri("http://api-theatre.herokuapp.com") };
            //var jsonContens = await client.GetStringAsync("/utils/updates?stamp=" + App.Current.Properties["timestamp"]);
            var jsonContens = await client.GetStringAsync("/utils/updates?stamp=0");
            var o = JObject.Parse(jsonContens);
            var performances = JsonConvert.DeserializeObject<List<Performance>>(o.SelectToken(@"$.response.perfs").ToString());

            var realm = new RealmDBService();
            foreach (var performance in performances)
            {
                var newPerformance = new Performance
                {
                    id = performance.id,
                    author = performance.author,
                    desc = performance.desc,
                    hall_name = performance.hall_name,
                    img = performance.img,
                    name = performance.name,
                    near = performance.near
                };

                foreach (var poster in performance.posters)
                {
                    newPerformance.posters.Add(poster);
                }
                
                realm.SavePerfomance(newPerformance);
            }
        }
    }
}