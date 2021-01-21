using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaAlertFeedBack
    {
        public long Id { get; set; }
        public string 反馈人 { get; set; }
        public DateTime? 反馈时间 { get; set; }
        public string 反馈内容 { get; set; }
    }
}
