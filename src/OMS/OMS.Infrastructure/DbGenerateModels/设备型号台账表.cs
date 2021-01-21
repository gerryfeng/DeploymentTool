using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备型号台账表
    {
        public int Id { get; set; }
        public string 所属站点 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 设备型号 { get; set; }
        public string 生产厂家 { get; set; }
        public string 防护等级 { get; set; }
        public string 图片 { get; set; }
        public string 公称直径 { get; set; }
        public string 过载流量 { get; set; }
        public string 常用流量 { get; set; }
        public string 分界流量 { get; set; }
        public string 最小流量 { get; set; }
        public string 量程比 { get; set; }
        public string 压力 { get; set; }
        public string 重量 { get; set; }
        public string 设备类型 { get; set; }
        public string 编码规则 { get; set; }
        public int? 地址版本id { get; set; }
        public string ReadMode { get; set; }
        public string 测量范围 { get; set; }
        public string 水表等级 { get; set; }
    }
}
