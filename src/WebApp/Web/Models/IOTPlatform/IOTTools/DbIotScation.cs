using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.IOTPlatform.IOTTools
{
    [Table("SCADA_Station")]
    public class DbIotScation
    {

        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("CODE")]
        public string CODE { get; set; }

        [Column("LedgerID")]
        public int LedgerID { get; set; }


    }
}
