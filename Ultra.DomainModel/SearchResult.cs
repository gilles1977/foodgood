using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultra.DomainModel
{
    public class SearchResult
    {
        public string Q { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
        public string Sort { get; set; }
        public string Fg { get; set; }
        public string Sr { get; set; }
        public IList<SearchItem> Items { get; set; }
    }

    public class SearchItem
    {
        public string Ndbno { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
    }
}
