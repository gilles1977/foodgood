using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ultra.DomainModel
{
    [DataContract]
    public class NutrientReportQuery
    {
        [DataMember(Name = "ndbno", EmitDefaultValue = false)]
        public string Ndbno { get; set; }

        [DataMember(Name = "nutrients", EmitDefaultValue = false)]
        public IList<string> Nutrients { get; set; }

        [DataMember(Name = "fg", EmitDefaultValue = false)]
        public string Fg { get; set; }

        [DataMember(Name = "sort", EmitDefaultValue = false)]
        public string Sort { get; set; }

        [DataMember(Name = "max", EmitDefaultValue = false)]
        public string Max { get; set; }

        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public string Offset { get; set; }

        [DataMember(Name = "subset", EmitDefaultValue = false)]
        public string Subset { get; set; }
    }
}
