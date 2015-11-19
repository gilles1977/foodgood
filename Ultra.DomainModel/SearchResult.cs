using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ultra.DomainModel
{
    [DataContract]
    public class SearchResult
    {
        [DataMember(Name = "list")]
        public Result List { get; set; }
    }
    
    public class Result
    {
        [DataMember(Name = "q")]
        public string Q { get; set; }
        [DataMember(Name = "sr")]
        public string Sr { get; set; }
        [DataMember(Name = "start")]
        public int Start { get; set; }
        [DataMember(Name = "end")]
        public int End { get; set; }
        [DataMember(Name = "total")]
        public int Total { get; set; }
        [DataMember(Name = "group")]
        public string Fg { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "item")]
        public IList<SearchItem> Item { get; set; }
    }

    public class SearchItem
    {
        [DataMember(Name = "offset")]
        public int Offset { get; set; }
        [DataMember(Name = "group")]
        public string Group { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "ndbno")]
        public string Ndbno { get; set; }

    }
}
