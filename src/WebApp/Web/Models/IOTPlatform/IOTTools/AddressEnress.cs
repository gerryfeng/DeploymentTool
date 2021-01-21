using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Utils.IOTTools
{
    public class AddressEnress
    {

        [Column("名称")]
        public string Name { get; set; }

    }
}
