using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护区域表
    {
        public long Id { get; set; }
        public string 区域名称 { get; set; }
        public string 路径坐标 { get; set; }
        public string 区域坐标 { get; set; }
        public int? 区域类型 { get; set; }
        public int? 上级区域id { get; set; }
        public string 站点 { get; set; }
        public string 用户id { get; set; }
        public string 用户名称 { get; set; }
        public string 业务名称 { get; set; }
        public int IsExist { get; set; }
    }
}
