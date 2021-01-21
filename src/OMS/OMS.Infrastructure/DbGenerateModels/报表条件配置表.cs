using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 报表条件配置表
    {
        public long Id { get; set; }
        public string 方案名 { get; set; }
        public string 条件名 { get; set; }
        public string 别名 { get; set; }
        public string 形态 { get; set; }
        public string 单位 { get; set; }
        public int? 跨距 { get; set; }
        public string 配置信息 { get; set; }
        public string 预设值 { get; set; }
    }
}
