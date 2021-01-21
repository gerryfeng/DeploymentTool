using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 数据实时水源井
    {
        public int Id { get; set; }
        public string 设备编码 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public DateTime? 采集时间 { get; set; }
        public int? 是否在线 { get; set; }
        public DateTime? 上线时间 { get; set; }
        public float? 在线时长 { get; set; }
        public DateTime? 离线时间 { get; set; }
        public float? 离线时长 { get; set; }
        public int? 是否报警 { get; set; }
        public string 当前报警 { get; set; }
        public float? 报警时长 { get; set; }
        public float? A相电流 { get; set; }
        public float? A相电压 { get; set; }
        public float? B相电流 { get; set; }
        public float? B相电压 { get; set; }
        public float? C相电流 { get; set; }
        public float? C相电压 { get; set; }
        public int? Md初始化代码 { get; set; }
        public int? Md初始完成 { get; set; }
        public int? Md通讯错误代码 { get; set; }
        public int? 泵故障信号 { get; set; }
        public int? 泵启动超时 { get; set; }
        public int? 泵启动信号i { get; set; }
        public int? 泵状态 { get; set; }
        public int? 泵自动 { get; set; }
        public float? 出水压力 { get; set; }
        public int? 防盗报警 { get; set; }
        public float? 功率因数 { get; set; }
        public int? 故障复位 { get; set; }
        public int? 合闸信号 { get; set; }
        public float? 累计单位 { get; set; }
        public float? 累计流量 { get; set; }
        public float? 命令组 { get; set; }
        public int? 启动录像 { get; set; }
        public int? 全压运行 { get; set; }
        public float? 水井液位 { get; set; }
        public float? 瞬时流量 { get; set; }
        public float? 无功电能 { get; set; }
        public float? 有功电能 { get; set; }
        public int? 远程启动 { get; set; }
        public int? 远程启动允许 { get; set; }
        public int? 远程停止 { get; set; }
        public float? 站点在线状态 { get; set; }
        public float? 今日用电量 { get; set; }
        public float? 今日取水量 { get; set; }
    }
}
