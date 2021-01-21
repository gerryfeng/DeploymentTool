using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单功能集成配置表
    {
        public long Id { get; set; }
        public string 组名 { get; set; }
        public string 标签名称 { get; set; }
        public string 视图模块 { get; set; }
        public int 显示顺序 { get; set; }
    }
}
