using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备巡维保任务表
    {
        public int Id { get; set; }
        public string 任务编码 { get; set; }
        public string 计划编码 { get; set; }
        public string 设备编码 { get; set; }
        public DateTime? 开始时间 { get; set; }
        public DateTime? 结束时间 { get; set; }
        public DateTime? 完成时间 { get; set; }
        public string 执行人 { get; set; }
        public string 完成人 { get; set; }
        public string 任务状态 { get; set; }
        public string 事件编号 { get; set; }
        public string 分派人 { get; set; }
        public DateTime? 分派时间 { get; set; }
        public string 任务类型 { get; set; }
        public string 反馈间隔 { get; set; }
        public string 反馈距离 { get; set; }
        public string 模板名称 { get; set; }
        public string 备注 { get; set; }
    }
}
