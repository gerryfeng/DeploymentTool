using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 监控二供维保台账表
    {
        public int Id { get; set; }
        public string 维保编号 { get; set; }
        public string 所属泵房 { get; set; }
        public string 维保状态 { get; set; }
        public string 维保人员 { get; set; }
        public DateTime? 维保时间 { get; set; }
        public string 现场照片 { get; set; }
        public string 维保说明 { get; set; }
        public string 维保项目 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 保养编号 { get; set; }
        public string 保养状态 { get; set; }
        public string 保养人员 { get; set; }
        public DateTime? 保养时间 { get; set; }
        public string 保养说明 { get; set; }
        public string 保养项目 { get; set; }
        public string 保养周期 { get; set; }
        public string 维修说明 { get; set; }
        public string 是否维修 { get; set; }
        public string 维修状态 { get; set; }
    }
}
