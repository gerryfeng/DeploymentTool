using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdWxCaseback
    {
        public long Id { get; set; }
        public long? CaseId { get; set; }
        public string 退单人id { get; set; }
        public string 退单人 { get; set; }
        public DateTime? 退单时间 { get; set; }
        public string 原因 { get; set; }
    }
}
