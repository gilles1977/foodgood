using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Ultra.Tools;

namespace Ultra.DomainModel
{
    [DataContract]
    public class NutrientReportResult
    {
        [DataMember(Name = "report")]
        public NutrientReport Report { get; set; }
    }
    public class NutrientReport
    {
        [DataMember, JsonProperty(PropertyName = "groups")]
        [JsonConverter(typeof(SingleValueArrayConverter<FoodGroup>))]
        public IList<FoodGroup> Groups { get; set; }
        
        [DataMember(Name = "subset")]
        public string Subset { get; set; }

        [DataMember(Name = "sr")]
        public string Sr { get; set; }

        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "end")]
        public int End { get; set; }

        [DataMember(Name = "total")]
        public int Total { get; set; }

        public IList<Food> Foods { get; set; }
    }

    public class FoodGroup
    {
        public string Groups { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class Food
    {
        [DataMember(Name = "ndbno")]
        public string Ndbno { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "weight")]
        public float Weight { get; set; }

        [DataMember(Name = "measure")]
        public string Measure { get; set; }

        [DataMember(Name = "nutrients")]
        public IList<Nutrient> Nutrients { get; set; }
    }

    public class Nutrient
    {
        [DataMember, JsonProperty(PropertyName = "nutrient_id")]
        public string NutrientId { get; set; }

        [DataMember, JsonProperty(PropertyName = "nutrient")]
        public string Description { get; set; }

        [DataMember(Name = "unit")]
        public string Unit { get; set; }

        [DataMember(Name = "gm")]
        public string Gm { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}
