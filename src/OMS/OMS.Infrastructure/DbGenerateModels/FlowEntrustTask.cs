using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowEntrustTask
    {
        public int 委托id { get; set; }
        public int 活动id { get; set; }
        public int 是否有委托权 { get; set; }
    }
}
