using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Notification消息配置表
    {
        public int Id { get; set; }
        public string 主题名称 { get; set; }
        public string 消息类型 { get; set; }
        public string 公众号模板id { get; set; }
        public string 公众号配置 { get; set; }
        public string 公众号路径 { get; set; }
        public string 短信模板名称 { get; set; }
        public string 短信模板编号 { get; set; }
        public string 短信配置 { get; set; }
        public string 小程序路由 { get; set; }
        public string App功能路径 { get; set; }
        public string App配置 { get; set; }
        public string Web功能路径 { get; set; }
        public string Web配置 { get; set; }
        public int? 是否删除 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public string 推送人 { get; set; }
        public string 推送方式 { get; set; }
        public string 推送路径 { get; set; }
        public string 是否启动 { get; set; }
        public int? 短信模板id { get; set; }
        public int? App模板id { get; set; }
        public int? Web模板id { get; set; }
        public string 推送组 { get; set; }
    }
}
