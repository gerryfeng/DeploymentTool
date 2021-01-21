using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolCheck
    {
        public long Id { get; set; }
        public string 事件编号 { get; set; }
        public string 工单编号 { get; set; }
        public string 事件名称 { get; set; }
        public string 事件状态 { get; set; }
        public string 处理站点 { get; set; }
        public string 坐标位置 { get; set; }
        public string Name { get; set; }
        public int? CheckerId { get; set; }
        public string CheckerName { get; set; }
        public DateTime? CheckTime { get; set; }
        public string Reason { get; set; }
        public int? IsPass { get; set; }
        public int? 上报人id { get; set; }
        public string 上报人名称 { get; set; }
        public string 上报人部门 { get; set; }
        public DateTime? 上报时间 { get; set; }
        public string 上报站点 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public string 更新状态 { get; set; }
        public string 现场图片 { get; set; }
        public string 现场录音 { get; set; }
        public int? 是否置顶 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
