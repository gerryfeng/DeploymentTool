using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowSupervision
    {
        public int 督办id { get; set; }
        public int? 督办人id { get; set; }
        public string 督办人名称 { get; set; }
        public string 督办意见 { get; set; }
        public DateTime? 督办时间 { get; set; }
    }
}
