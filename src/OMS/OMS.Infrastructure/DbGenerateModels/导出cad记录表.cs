using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 导出cad记录表
    {
        public int Id { get; set; }
        public int 用户id { get; set; }
        public DateTime 导出时间 { get; set; }
        public string 地图服务名 { get; set; }
        public string 范围 { get; set; }
        public string 文件名 { get; set; }
    }
}
