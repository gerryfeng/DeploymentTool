using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Configure
{
    public class ModelFeature
    {

        public ModelFeature() {
            feature = new List<Features>();
        }

        public string type { get; set; }
        public List<Features> feature { get; set; }
    }
}
