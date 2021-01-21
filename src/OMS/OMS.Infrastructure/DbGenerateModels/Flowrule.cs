using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Flowrule
    {
        public int 规则id { get; set; }
        public string 规则名称 { get; set; }
        public string 规则表达式 { get; set; }
        public string 描述信息 { get; set; }
        public string 参数列表 { get; set; }
        public string Iscompile { get; set; }
        public byte[] Assembly { get; set; }
    }
}
