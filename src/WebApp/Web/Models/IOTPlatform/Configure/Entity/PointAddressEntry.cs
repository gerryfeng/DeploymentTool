using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.IOTPlatform.Configure.Entity
{
    [Table("PointAddressEntry")]
    public class PointAddressEntry
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("名称")]
        public string Name { get; set; }

        [Column("数据源地址")]
        public string dataSourceAddress { get; set; }

        [Column("版本ID")]
        public int VersionID { get; set; }


    }
}
