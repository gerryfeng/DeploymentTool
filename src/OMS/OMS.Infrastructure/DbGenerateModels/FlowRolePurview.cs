using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowRolePurview
    {
        public int 活动id { get; set; }
        public int 机构id { get; set; }
        public string 默认承办人 { get; set; }
        public string 备注 { get; set; }
    }
}
