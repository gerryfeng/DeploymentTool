using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Scada远程控制远程控制操作日志
    {
        public int Id { get; set; }
        public string 操作人 { get; set; }
        public DateTime? 操作时间 { get; set; }
        public string 设备编码 { get; set; }
        public string 控制点位 { get; set; }
        public string 控制结果 { get; set; }
        public int? 控制等待时间 { get; set; }
        public string 初始状态 { get; set; }
        public string 目标状态 { get; set; }
        public string 实际状态 { get; set; }
        public string 请求路径 { get; set; }
        public string 服务返回信息 { get; set; }
        public int? 物联设备类型 { get; set; }
        public string 控制类型 { get; set; }
        public string 策略类型 { get; set; }
    }
}
