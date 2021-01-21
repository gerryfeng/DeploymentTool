using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 探漏探漏结果表
    {
        public int Id { get; set; }
        public string 漏损上限 { get; set; }
        public string 结论 { get; set; }
        public int? 是否删除 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public string 漏损下限 { get; set; }
    }
}
