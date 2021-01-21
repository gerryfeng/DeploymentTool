using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单用户关注表
    {
        public long Id { get; set; }
        public int? 用户id { get; set; }
        public string 流程名称 { get; set; }
        public string 工单编号 { get; set; }
    }
}
