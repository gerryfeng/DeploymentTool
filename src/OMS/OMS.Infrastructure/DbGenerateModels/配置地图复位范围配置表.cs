using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 配置地图复位范围配置表
    {
        public int Id { get; set; }
        public int 机构id { get; set; }
        public string 区域名称 { get; set; }
        public string 地图范围 { get; set; }
    }
}
