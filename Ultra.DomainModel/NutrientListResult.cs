using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ultra.DomainModel
{
    [DataContract]
    public class NutrientListResult
    {
        [DataMember(Name = "type")]
        public string ListType { get; set; }

        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "end")]
        public int End { get; set; }

        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "sort")]
        public string Sort { get; set; }

        [DataMember(Name = "sr")]
        public string StandardRelease { get; set; }

        [DataMember(Name = "item")]
        public IList<ListItem> Items { get; set; }
    }

    public class ListItem
    {
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
