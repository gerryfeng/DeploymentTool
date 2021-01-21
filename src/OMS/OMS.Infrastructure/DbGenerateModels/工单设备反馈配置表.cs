using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单设备反馈配置表
    {
        public long Id { get; set; }
        public string 图层名称 { get; set; }
        public string 流程名称 { get; set; }
        public string 节点名称 { get; set; }
        public string 反馈表名 { get; set; }
        public string 字段集 { get; set; }
        public string Gis图层 { get; set; }
        public string Gis过滤条件 { get; set; }
        public int? 是否删除 { get; set; }
        public int? 顺序 { get; set; }
        public string 分组类型 { get; set; }
        public string 站点 { get; set; }
        public string 触发异常值 { get; set; }
        public string 触发事件 { get; set; }
    }
}
