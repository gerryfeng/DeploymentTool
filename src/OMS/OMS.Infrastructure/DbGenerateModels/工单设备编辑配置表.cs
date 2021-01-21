using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单设备编辑配置表
    {
        public long Id { get; set; }
        public string 图层名称 { get; set; }
        public string 反馈表名 { get; set; }
        public string 字段集 { get; set; }
        public string Gis图层 { get; set; }
        public string Gis过滤条件 { get; set; }
        public int? 图层类型 { get; set; }
    }
}
