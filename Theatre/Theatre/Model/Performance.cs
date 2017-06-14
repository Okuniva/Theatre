using System.Collections.Generic;
using Newtonsoft.Json;
using Realms;

namespace Theatre.Model
{
    public class Performance : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string desc { get; set; }
        public string img { get; set; }
        public string author { get; set; }
        public string name { get; set; }
        public int p_type_id { get; set; }
        public int theatre_id { get; set; }
        public string theatre_name { get; set; }
        public string hall_name { get; set; }
        public bool IsFavorite { get; set; }
        public List<int> actors { get; }
        public string near { get; set; }
        public IList<Poster> posters { get; }
    }
}
