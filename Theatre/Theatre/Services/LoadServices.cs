using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Theatre.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using PCLStorage;
using Plugin.Settings;
using Xamarin.Forms;

namespace Theatre.Services
{
    public class LoadServices
    {
        private static readonly HttpClient _client =
            new HttpClient() {BaseAddress = new Uri("http://api-theatre.herokuapp.com")};

        public async Task PdfTicketLoad(int id, string name, string img, string place, string date, IDBService dbService)
        {
            var ticket = new Ticket() { id = id, name = name, img = img, file_name = place.Replace('-', '_'), date = date};
            dbService.SaveTicket(ticket);
            byte[] pdfByteArray = await _client.GetByteArrayAsync("/tickets/get_pdf/" + id + "/" + place);
            Debug.WriteLine("pdf loaded");

            IFolder folder = FileSystem.Current.LocalStorage;
            IFile file = await folder.CreateFileAsync(id + place.Replace('-', '_'), CreationCollisionOption.ReplaceExisting);
            using (System.IO.Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                stream.Write(pdfByteArray, 0, pdfByteArray.Length);
            }
        }

        public async void ResetAllData(IDBService dbService)
        {
            var jsonContens = await _client.GetStringAsync("/utils/updates?stamp=" +
                                                           CrossSettings.Current.GetValueOrDefault<string>("timestamp",
                                                               "0"));
            var data = JsonConvert.DeserializeObject<RootObject>(jsonContens);

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

                //newPerformance.actors = performance.actors;
                //foreach (var actor in performance.actors)
                //{
                //    newPerformance.actors.Add(actor);
                //}

                foreach (var poster in performance.posters)
                {
                    newPerformance.posters.Add(poster);
                }

                dbService.SavePerfomance(newPerformance);
            }

            foreach (var article in data.response.articles)
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

            Debug.WriteLine(data.response.performances.Count);
            CrossSettings.Current.AddOrUpdateValue<string>("timestamp", data.response.timestamp);
        }

        public async Task RefreshPerformance(IDBService dbService)
        {
            var jsonContens = await _client.GetStringAsync("/utils/updates?stamp=" +
                                                           CrossSettings.Current.GetValueOrDefault<string>("timestamp",
                                                               "0"));

            JObject o = JObject.Parse(jsonContens);
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

                //foreach (var actor in performance.actors)
                //{
                //    newPerformance.actors.Add(actor);
                //}
                //newPerformance.actors.AddRange(performance.actors);

                foreach (var poster in performance.posters)
                {
                    newPerformance.posters.Add(poster);
                }

                dbService.SavePerfomance(newPerformance);
            }
        }

        public async Task<Dictionary<string, string>> GetSeats(int id)
        {
            var jsonContens = await _client.GetStringAsync("/tickets/seats/" + id);
            var o = JObject.Parse(jsonContens);
            var seats = JsonConvert.DeserializeObject<Dictionary<string, string>>(o.SelectToken(@"$.response.prices").ToString());

            return seats;
        }
    }
}