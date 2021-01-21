using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Configure.Entity;
using Web.Models.IOTPlatform.Configure.Entity;

namespace Web.DTO.Configure
{
    public class SketchpadDetailListDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        public List<PointAddressEntry> list { get; set; }
    }
}
