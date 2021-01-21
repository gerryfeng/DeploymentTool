using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Configure.Entity
{

    [Table("PointAddress")]
    public class PointAddress
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("FVersion")]
        public string FVersion { get; set; }

        [Column("FName")]
        public string  FName { get; set; }

        [Column("FStartAddress")]
        public string ? FStartAddress { get; set; }

        [Column("FAddressLength")]
        public int ? FAddressLength { get; set; }

        [Column("FNote")]
        public string ? FNote { get; set; }

        [Column("FCreateDate")]
        public DateTime ? FCreateDate { get; set; }

        [Column("FIsDelete")]
        public int ? FIsDelete { get; set; }
     

    }
}
