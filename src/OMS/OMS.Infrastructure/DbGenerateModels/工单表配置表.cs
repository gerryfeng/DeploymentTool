using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单表配置表
    {
        public long Id { get; set; }
        public string 表名 { get; set; }
        public string 别名 { get; set; }
        public string 导出模板 { get; set; }
        public string 显示模板 { get; set; }
        public string 表格样式 { get; set; }
        public string 接口配置 { get; set; }
    }
}
