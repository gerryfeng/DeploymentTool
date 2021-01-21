using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 配置设备信息拓展表
    {
        public int Id { get; set; }
        public string 设备编码 { get; set; }
        public string 地址方案 { get; set; }
        public string 工艺画板名称 { get; set; }
        public string 工艺画板参数 { get; set; }
        public string 卡片画板名称 { get; set; }
        public string 卡片画板参数 { get; set; }
        public string 列表画板名称 { get; set; }
        public string 列表画板参数 { get; set; }
        public string Tip画板名称S { get; set; }
        public string Tip画板参数S { get; set; }
        public string Tip画板名称M { get; set; }
        public string Tip画板参数M { get; set; }
        public string Tip画板名称L { get; set; }
        public string Tip画板参数L { get; set; }
    }
}
