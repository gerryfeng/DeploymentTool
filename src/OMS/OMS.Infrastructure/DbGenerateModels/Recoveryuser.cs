using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Recoveryuser
    {
        public int Id { get; set; }
        public int? 用户id { get; set; }
        public string 工号 { get; set; }
        public string 名称 { get; set; }
        public int? 机构id { get; set; }
        public string 机构名称 { get; set; }
        public string 用户信息 { get; set; }
        public int? 隐藏 { get; set; }
        public DateTime? 插入时间 { get; set; }
        public int? 已恢复 { get; set; }
        public DateTime? 恢复时间 { get; set; }
    }
}
