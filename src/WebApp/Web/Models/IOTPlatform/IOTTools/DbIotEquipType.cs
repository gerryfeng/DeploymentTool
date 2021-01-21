using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web.Utils.IOTTools;

namespace Web.DTO.IOTTools
{
 
   [Table("配置_物联设备类型配置表")]
    public class DbIotEquipType
    {

        [Column("ID")]
        public int ID { get; set; }

        [Column("设备类型")]
        public string Name { get; set; }

        [Column("分组名称")]
        public string GroupName { get; set; }

        [Column("父类型名称")]
        public string ParentName { get; set; }

        [Column("台账表名")]
        public string LedgerTableName { get; set; }

        [Column("实时数据表名")]
        public string RealTimeTableName { get; set; }

        [Column("历史数据表名")]
        public string HistoryTableName { get; set; }

        [Column("统计数据表名")]
        public string StaticsTableName { get; set; }

        [Column("地址方案名")]
        public string AddrSchemeName { get; set; }

        [NotMapped]
        public List<string> AddressEntrss { get; set; }


    }
}
