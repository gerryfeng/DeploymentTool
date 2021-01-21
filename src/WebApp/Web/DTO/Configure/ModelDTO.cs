using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Configure.Entity;

namespace Web.DTO
{
    public class ModelDTO
    {
        public string Type { get; set; }

        public List<ModelQueryDTO> list { get; set; }

    }
}
