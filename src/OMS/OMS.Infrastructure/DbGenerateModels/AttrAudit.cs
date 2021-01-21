using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class AttrAudit
    {
        public int Id { get; set; }
        public string 图层标识 { get; set; }
        public string 设备标识 { get; set; }
        public string 操作 { get; set; }
        public string 属性字段 { get; set; }
        public string 原值 { get; set; }
        public string 新值 { get; set; }
        public string 提交人 { get; set; }
        public DateTime? 提交时间 { get; set; }
        public DateTime? 审核时间 { get; set; }
        public string 审核状态 { get; set; }
        public string 审核信息 { get; set; }
        public string 审核人 { get; set; }
        public string Caseno { get; set; }
        public string 几何类型 { get; set; }
        public string 几何范围 { get; set; }
        public string 描述 { get; set; }
        public string EventId { get; set; }
        public string 操作名称 { get; set; }
        public string 提交人部门 { get; set; }
    }
}
