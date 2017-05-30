using Newtonsoft.Json;
using Realms;

namespace Theatre.Model
{
    public class Poster : RealmObject
    {
        public int id { get; set; }
        public string date { get; set; }
    }
}