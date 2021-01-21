using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单材料库表
    {
        public long Id { get; set; }
        public string 材料类型 { get; set; }
        public string 材料名称 { get; set; }
        public string 材料编号 { get; set; }
        public string 规格 { get; set; }
        public string 单位 { get; set; }
        public double? 价格 { get; set; }
        public string 厂商 { get; set; }
        public double? 库存量 { get; set; }
    }
}
