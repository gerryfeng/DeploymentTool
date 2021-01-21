using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单材料配置表
    {
        public int Id { get; set; }
        public string 设备类型 { get; set; }
        public string 保养类型 { get; set; }
        public string 材料名称 { get; set; }
        public string 材料默认值 { get; set; }
        public string 业务名称 { get; set; }
    }
}
