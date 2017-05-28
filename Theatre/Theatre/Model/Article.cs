using Realms;

namespace Theatre.Model
{
    public class Article : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string img { get; set; }
        public string date { get; set; }
        public string theatre_name { get; set; }
    }
}