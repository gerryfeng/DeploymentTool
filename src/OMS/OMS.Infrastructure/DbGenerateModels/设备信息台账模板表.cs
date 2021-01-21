using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备信息台账模板表
    {
        public int Id { get; set; }
        public string 设备名称 { get; set; }
        public string 设备简称 { get; set; }
        public string 编码 { get; set; }
        public string 父设备编码 { get; set; }
        public string 坐标位置 { get; set; }
        public string 详细地址 { get; set; }
        public string 地址方案名 { get; set; }
        public string 地址方案版本 { get; set; }
        public decimal? 采集频率 { get; set; }
        public decimal? 存储频率 { get; set; }
        public string Gis编码 { get; set; }
        public string 第三方编码 { get; set; }
        public string 风貌图 { get; set; }
        public string 视频缩略图 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 画板名称 { get; set; }
        public string 设备类型 { get; set; }
        public string 设备分类 { get; set; }
        public int? 接入状态 { get; set; }
        public string 录入人 { get; set; }
        public string Sn码 { get; set; }
        public int? 录入人id { get; set; }
        public string 物联返回信息 { get; set; }
        public string 采集编码 { get; set; }
        public string 采集协议 { get; set; }
        public int? 顺序 { get; set; }
    }
}
