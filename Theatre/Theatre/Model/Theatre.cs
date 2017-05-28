using Realms;

namespace Theatre.Model
{
    public class Theatre : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string img { get; set; }
        public string address { get; set; }
    }

}
