using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdWxReport
    {
        public long Id { get; set; }
        public long? Caseid { get; set; }
        public string 类型名 { get; set; }
        public int? 上报人id { get; set; }
        public string 上报人 { get; set; }
        public string 上报人部门 { get; set; }
        public DateTime? 上报时间 { get; set; }
        public string 照片 { get; set; }
        public string 录音 { get; set; }
        public string 描述 { get; set; }
    }
}
