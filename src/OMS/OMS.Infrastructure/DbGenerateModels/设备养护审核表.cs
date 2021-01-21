using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护审核表
    {
        public long Id { get; set; }
        public string 事件编号 { get; set; }
        public string 工单编号 { get; set; }
        public string 事件名称 { get; set; }
        public string 事件状态 { get; set; }
        public string 处理站点 { get; set; }
        public string 坐标位置 { get; set; }
        public int? 上报人id { get; set; }
        public string 上报人名称 { get; set; }
        public string 上报人部门 { get; set; }
        public DateTime? 上报时间 { get; set; }
        public string 上报站点 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public string 更新状态 { get; set; }
        public string 送审名称 { get; set; }
        public int? 审核人id { get; set; }
        public string 审核人姓名 { get; set; }
        public DateTime? 审核时间 { get; set; }
        public int? 是否通过 { get; set; }
        public string 不通过原因 { get; set; }
        public string 业务名称 { get; set; }
        public string 现场图片 { get; set; }
        public string 现场录音 { get; set; }
        public int? 是否置顶 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
