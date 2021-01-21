using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 配置系统信息表
    {
        public int Id { get; set; }
        public int? 父配置项id { get; set; }
        public string 配置项名称 { get; set; }
        public string 配置项值 { get; set; }
        public int? 是否启用 { get; set; }
    }
}
