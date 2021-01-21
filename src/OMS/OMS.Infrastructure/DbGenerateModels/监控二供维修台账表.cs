using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 监控二供维修台账表
    {
        public int Id { get; set; }
        public string 维修编号 { get; set; }
        public string 所属泵房 { get; set; }
        public string 维修设备 { get; set; }
        public string 维修状态 { get; set; }
        public string 紧急程度 { get; set; }
        public string 维修来源 { get; set; }
        public string 维修人员 { get; set; }
        public DateTime? 维修时间 { get; set; }
        public string 现场照片 { get; set; }
        public string 维修说明 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public DateTime? 报障时间 { get; set; }
        public string 维修描述 { get; set; }
        public string 故障现象 { get; set; }
        public string 更换材料 { get; set; }
        public DateTime? 到场时间 { get; set; }
        public DateTime? 完工时间 { get; set; }
    }
}
