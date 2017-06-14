using Realms;

namespace Theatre.Model
{
    public class Ticket : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string file_name { get; set; }
        public string date { get; set; }
    }
}
