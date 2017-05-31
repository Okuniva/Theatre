using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Model
{
    public class Response
    {
        public int timestamp { get; set; }
        public List<Article> articles { get; set; }
        public List<Actor> actors { get; set; }
        public List<Performance> performances { get; set; }
        public List<Theatre> theatres { get; set; }
    }
}
