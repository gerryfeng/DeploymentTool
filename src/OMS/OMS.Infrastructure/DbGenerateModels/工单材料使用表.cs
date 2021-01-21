using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单材料使用表
    {
        public long Id { get; set; }
        public string 工单编号 { get; set; }
        public string 材料类型 { get; set; }
        public string 材料名称 { get; set; }
        public string 材料编号 { get; set; }
        public string 规格 { get; set; }
        public string 单位 { get; set; }
        public double? 价格 { get; set; }
        public string 厂商 { get; set; }
        public double? 数量 { get; set; }
        public string 添加人员 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public string 是否删除 { get; set; }
    }
}
