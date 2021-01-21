using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Flowtemprla
    {
        public int 流程id { get; set; }
        public int 线id { get; set; }
        public int? Stnod { get; set; }
        public int? Endnod { get; set; }
        public int? Len { get; set; }
        public byte[] Dat { get; set; }
        public int? 规则id { get; set; }
        public int? 分组 { get; set; }
        public int? 退回标记 { get; set; }
        public string 备注 { get; set; }
        public string 条件表达式 { get; set; }
    }
}
