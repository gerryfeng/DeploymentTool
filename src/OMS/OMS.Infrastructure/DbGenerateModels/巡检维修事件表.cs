using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 巡检维修事件表
    {
        public long Id { get; set; }
        public string 事件编号 { get; set; }
        public string 事件状态 { get; set; }
        public string 事件名称 { get; set; }
        public string 处理站点 { get; set; }
        public string 上报站点 { get; set; }
        public string 现场图片 { get; set; }
        public string 现场录音 { get; set; }
        public string 坐标位置 { get; set; }
        public string 上报人名称 { get; set; }
        public string 上报人部门 { get; set; }
        public DateTime? 上报时间 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public string 更新状态 { get; set; }
        public string 事件类型 { get; set; }
        public string 事件内容 { get; set; }
        public string 事发地址 { get; set; }
        public string 事件描述 { get; set; }
        public string 用户编号 { get; set; }
        public string 用户名称 { get; set; }
        public string 用户电话 { get; set; }
        public int? 是否置顶 { get; set; }
        public string 处理紧急程度 { get; set; }
        public string 处理时限 { get; set; }
        public string 建议处理方法 { get; set; }
        public DateTime? 接单时间 { get; set; }
        public string 接单描述 { get; set; }
        public DateTime? 到场时间 { get; set; }
        public string 到场描述 { get; set; }
        public string 处理结果 { get; set; }
        public string 完工照片 { get; set; }
        public string 备注 { get; set; }
        public string 审核意见 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
