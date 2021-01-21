using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.IOTTools
{
    public class HistoryCountReslut
    {
        // 历史数据信息结果

        [Column("总数")]
        public int CountNumber { get; set; }

        [Column("起始时间")]
        public DateTime startTime { get; set; }

        [Column("结束时间")]
        public DateTime endTime { get; set; }

        [NotMapped]
        public string Keys { get; set; }


    }
}
