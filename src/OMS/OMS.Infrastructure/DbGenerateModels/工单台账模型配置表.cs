using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单台账模型配置表
    {
        public long Id { get; set; }
        public string 业务类型 { get; set; }
        public string 台账名称 { get; set; }
        public string 台账表名 { get; set; }
        public string 台账字段集 { get; set; }
        public string 台账添加字段集 { get; set; }
        public string 台账编辑字段集 { get; set; }
        public string 前端显示字段集 { get; set; }
        public string 手持显示字段集 { get; set; }
        public string 接口配置 { get; set; }
        public int? 顺序 { get; set; }
        public string 检索字段集 { get; set; }
        public string 台账类型 { get; set; }
        public string 父台账名称 { get; set; }
        public string Gis图层 { get; set; }
        public string 业务反馈名称 { get; set; }
        public string Scada反馈名称 { get; set; }
        public string 设备图标 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
