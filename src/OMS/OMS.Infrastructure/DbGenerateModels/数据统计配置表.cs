using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 数据统计配置表
    {
        public int Id { get; set; }
        public string 表名 { get; set; }
        public string 设备类型名 { get; set; }
        public string 数据源集 { get; set; }
        public int? 脚本启用 { get; set; }
        public string 脚本语言 { get; set; }
        public string 脚本内容 { get; set; }
        public string 字段集 { get; set; }
        public string 备注 { get; set; }
        public string 缓存周期 { get; set; }
        public int? 临界容错时长 { get; set; }
    }
}
