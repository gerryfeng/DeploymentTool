using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 报警方案配置表
    {
        public int Id { get; set; }
        public string 方案名称 { get; set; }
        public string 设备类型 { get; set; }
        public string 方案类型 { get; set; }
        public string 报警类型 { get; set; }
        public string 组合规则 { get; set; }
        public string 推送方式 { get; set; }
        public string 推送人 { get; set; }
        public int? 是否启用 { get; set; }
        public int? 是否弹框 { get; set; }
        public int? 是否删除 { get; set; }
        public int? 是否弹窗 { get; set; }
        public int? 是否视频弹窗 { get; set; }
        public int? 推送组 { get; set; }
    }
}
