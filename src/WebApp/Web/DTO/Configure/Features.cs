using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Configure
{
    public class Features
    {
        [Column("特征")]
        public string features { get; set; }
    }
}
