using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备门禁信息表
    {
        public int Id { get; set; }
        public string 门禁名称 { get; set; }
        public string 设备编码 { get; set; }
        public string 第三方编码 { get; set; }
        public string 品牌 { get; set; }
        public string 型号 { get; set; }
        public string Ip { get; set; }
        public int? Port { get; set; }
        public string 用户名 { get; set; }
        public string 密码 { get; set; }
        public int? 在线状态 { get; set; }
        public string Rtmp { get; set; }
        public string Hls { get; set; }
        public int? 是否删除 { get; set; }
        public DateTime? 录入时间 { get; set; }
    }
}
