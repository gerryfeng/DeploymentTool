using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 探漏设备挂接表
    {
        public int Id { get; set; }
        public string 设备名称 { get; set; }
        public string 设备编码 { get; set; }
        public string 设备级别 { get; set; }
        public int? 所属方案 { get; set; }
        public string 安装位置 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
