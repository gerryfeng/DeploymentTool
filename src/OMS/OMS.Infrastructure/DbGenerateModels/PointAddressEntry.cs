using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PointAddressEntry
    {
        public int Id { get; set; }
        public int? 版本id { get; set; }
        public int? 点明细id { get; set; }
        public string 数据源地址 { get; set; }
        public string 偏移地址 { get; set; }
        public string 数据类型 { get; set; }
        public int? 数据长度 { get; set; }
        public int? 是否激活 { get; set; }
        public int? 是否归档 { get; set; }
        public int? 是否写入 { get; set; }
        public double? 倍率 { get; set; }
        public string 创建人 { get; set; }
        public DateTime? 创建时间 { get; set; }
        public string 值描述 { get; set; }
        public string 备注 { get; set; }
        public string 名称 { get; set; }
        public int? 传感器类型id { get; set; }
        public double? 偏差 { get; set; }
        public int? 脚本启用 { get; set; }
        public string 脚本语言 { get; set; }
        public string 脚本内容 { get; set; }
        public string 点来源 { get; set; }
        public double? 阀值上限 { get; set; }
        public double? 阀值下限 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 指标类型 { get; set; }
        public string 数据源集 { get; set; }
        public string 巡检分组 { get; set; }
        public string 控制脚本 { get; set; }
        public int? 排序 { get; set; }
        public int? 是否存储周期累加 { get; set; }
        public int? 控制启用 { get; set; }
        public string 父标签名称 { get; set; }
        public int? Sort { get; set; }
        public int? 表格显示 { get; set; }
        public int? 是否缩放 { get; set; }
        public double? 原始高 { get; set; }
        public double? 原始低 { get; set; }
        public double? 缩放高 { get; set; }
        public double? 缩放低 { get; set; }
        public string Plc地址 { get; set; }
        public double? 写入倍率 { get; set; }
    }
}
