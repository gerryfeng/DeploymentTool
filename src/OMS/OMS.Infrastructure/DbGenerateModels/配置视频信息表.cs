using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 配置视频信息表
    {
        public int Id { get; set; }
        public string 视频名称 { get; set; }
        public string 视频厂商 { get; set; }
        public string 视频类型 { get; set; }
        public string 登录名 { get; set; }
        public string 登录密码 { get; set; }
        public string 名称 { get; set; }
        public string 设备编码 { get; set; }
        public string 通道id { get; set; }
        public string 设备序列号 { get; set; }
        public string 视频路径 { get; set; }
        public string Hls路径 { get; set; }
        public string 登录ip { get; set; }
        public string 码流类型 { get; set; }
        public string 播放零通道 { get; set; }
        public string 流媒体端口 { get; set; }
        public string 设备端口 { get; set; }
        public string 视频端口 { get; set; }
        public int? 是否删除 { get; set; }
        public DateTime? 录入时间 { get; set; }
    }
}
