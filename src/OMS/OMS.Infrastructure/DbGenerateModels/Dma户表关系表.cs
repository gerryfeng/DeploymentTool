using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Dma户表关系表
    {
        public int Id { get; set; }
        public string 分区编码 { get; set; }
        public string 设备编码 { get; set; }
        public string 累流指标 { get; set; }
        public string 备注 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
