using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ultra.DomainModel
{
    [DataContract]
    public class NutrientListQuery
    {
        [DataMember(Name = "lt", EmitDefaultValue = false)]
        public string ListType { get; set; }

        [DataMember(Name = "max", EmitDefaultValue = false)]
        public int Max { get; set; }

        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int Offset { get; set; }

        [DataMember(Name = "sort", EmitDefaultValue = false)]
        public string Sort { get; set; }
    }
}
