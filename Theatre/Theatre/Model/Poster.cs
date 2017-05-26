using Newtonsoft.Json;
using Realms;

namespace Theatre.Model
{
    public class Poster : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string date { get; set; }
    }
}