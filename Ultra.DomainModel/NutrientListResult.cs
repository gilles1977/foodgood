using Newtonsoft.Json;
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
        [DataMember, JsonProperty(PropertyName = "list")]
        public NutrientList NutrientList { get; set; }
    }
    
    public class NutrientList
    {
        [DataMember, JsonProperty(PropertyName = "lt")]
        public string ListType { get; set; }

        [DataMember, JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [DataMember, JsonProperty(PropertyName = "end")]
        public int End { get; set; }

        [DataMember, JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        [DataMember, JsonProperty(PropertyName = "sort")]
        public string Sort { get; set; }

        [DataMember, JsonProperty(PropertyName = "sr")]
        public string StandardRelease { get; set; }

        [DataMember, JsonProperty(PropertyName = "item")]
        public IList<ListItem> Items { get; set; }
    }

    public class ListItem
    {
        [DataMember, JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }

        [DataMember, JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [DataMember, JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
