using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowDepoist
    {
        public int 沉淀id { get; set; }
        public int 案件记录 { get; set; }
        public int? 沉淀人 { get; set; }
        public DateTime? 沉淀时间 { get; set; }
        public string 沉淀意见 { get; set; }
        public int? 沉淀天数 { get; set; }
        public int 是否永久沉淀 { get; set; }
        public int 沉淀状态 { get; set; }
        public string 备注 { get; set; }
    }
}
