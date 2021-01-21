using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 数据统计周期脚本配置表
    {
        public int Id { get; set; }
        public string 缓存类型 { get; set; }
        public string 脚本 { get; set; }
        public string 缓存周期 { get; set; }
        public string 缓存类型名称 { get; set; }
    }
}
