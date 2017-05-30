using Realms;

namespace Theatre.Model
{
    public class Actor : RealmObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string img { get; set; }
    }
}