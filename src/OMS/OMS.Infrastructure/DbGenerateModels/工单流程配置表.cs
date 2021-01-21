using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单流程配置表
    {
        public long Id { get; set; }
        public string 流程名称 { get; set; }
        public string 办理页面 { get; set; }
        public string 手持办理页面 { get; set; }
        public int? 关闭事件 { get; set; }
        public string 接口配置 { get; set; }
        public int? 自定义前缀 { get; set; }
        public int? 显示顺序 { get; set; }
    }
}
