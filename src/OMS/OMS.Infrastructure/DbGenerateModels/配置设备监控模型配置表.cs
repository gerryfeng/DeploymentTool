using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 配置设备监控模型配置表
    {
        public int Id { get; set; }
        public string 设备类型 { get; set; }
        public string 设备类型简称 { get; set; }
        public string 配置规则 { get; set; }
        public string 生效条件 { get; set; }
        public string 设备图例 { get; set; }
        public string 卡片指标 { get; set; }
        public string 卡片重点指标 { get; set; }
        public string 列表指标 { get; set; }
        public string 表格指标 { get; set; }
        public string 单指标tip指标 { get; set; }
        public string 大tip指标 { get; set; }
        public string 画板名称 { get; set; }
        public string 画板设备类型 { get; set; }
        public string 画板参数 { get; set; }
        public string 详情指标 { get; set; }
        public string 卡片模板 { get; set; }
        public string 详情模板 { get; set; }
    }
}
