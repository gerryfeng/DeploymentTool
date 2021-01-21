using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowEntrust
    {
        public int 委托id { get; set; }
        public int 主管人id { get; set; }
        public DateTime? 委托日期 { get; set; }
        public DateTime? 生效日期 { get; set; }
        public string 委托人 { get; set; }
        public int? 委托人id { get; set; }
        public string 委托类型 { get; set; }
        public string 代理人 { get; set; }
        public int? 代理人id { get; set; }
        public int 状态 { get; set; }
        public int 是否手动注销 { get; set; }
        public DateTime? 取消日期 { get; set; }
        public int 是否需要确认 { get; set; }
        public int 是否全权委托 { get; set; }
        public string 备注 { get; set; }
    }
}
