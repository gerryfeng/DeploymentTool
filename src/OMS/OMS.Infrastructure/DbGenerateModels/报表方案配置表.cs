using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 报表方案配置表
    {
        public long Id { get; set; }
        public string 方案名 { get; set; }
        public string 方案分组 { get; set; }
        public string 导出模板 { get; set; }
        public string 前端模板 { get; set; }
        public int? 显示顺序 { get; set; }
        public string 导出方式 { get; set; }
        public string 查询数据库 { get; set; }
    }
}
