using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ultra.DomainModel
{
    [DataContract]
    public class NutrientReportResult
    {
        [DataMember(Name = "group")]
        public string Group { get; set; }

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

    public class Food
    {
        [DataMember(Name = "ndbno")]
        public string Ndbno { get; set; }

        [DataMember(Name = "nutrients")]
        public IList<Nutrient> Nutrients { get; set; }
    }

    public class Nutrient
    {
        [DataMember(Name = "nutrient_id")]
        public string NutrientId { get; set; }

        [DataMember(Name = "nutrient")]
        public string Description { get; set; }

        [DataMember(Name = "unit")]
        public string Unit { get; set; }

        [DataMember(Name = "gm")]
        public string Gm { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}
