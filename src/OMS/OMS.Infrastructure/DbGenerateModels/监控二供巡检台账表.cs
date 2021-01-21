using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 监控二供巡检台账表
    {
        public int Id { get; set; }
        public string 巡检编号 { get; set; }
        public string 所属泵房 { get; set; }
        public DateTime? 巡检时间 { get; set; }
        public string 巡检人员 { get; set; }
        public string 门禁状态 { get; set; }
        public string 渗透状态 { get; set; }
        public string 卫生状态 { get; set; }
        public string 噪音状态 { get; set; }
        public string 温度状态 { get; set; }
        public string 湿度状态 { get; set; }
        public string 管道状态 { get; set; }
        public string 阀件状态 { get; set; }
        public string 进出水压力状态 { get; set; }
        public string 电压状态 { get; set; }
        public string 电流状态 { get; set; }
        public string 电量状态 { get; set; }
        public string 频率状态 { get; set; }
        public string 液位状态 { get; set; }
        public string 泵运行状态 { get; set; }
        public string 控制柜状态 { get; set; }
        public string 现场照片 { get; set; }
        public string 反馈信息 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 门禁系统 { get; set; }
        public string 设备噪音 { get; set; }
        public string 室内温度 { get; set; }
        public string 除湿设备 { get; set; }
        public string 管道检测 { get; set; }
        public string 阀件检测 { get; set; }
        public string 进压检测 { get; set; }
        public string 电压检测 { get; set; }
        public string 电流检测 { get; set; }
        public string 电量检测 { get; set; }
        public string 频率检测 { get; set; }
        public string 液位检测 { get; set; }
        public string 控制柜plc { get; set; }
        public string 视频系统 { get; set; }
        public string 通讯设备 { get; set; }
        public string 通风设备 { get; set; }
        public string 消毒设备 { get; set; }
        public string 排污设备 { get; set; }
        public string 室内湿度 { get; set; }
        public string 泵体振动 { get; set; }
        public string 出压检测 { get; set; }
        public string 设备渗漏 { get; set; }
        public string 设备锈蚀 { get; set; }
        public string 变频器 { get; set; }
        public string 元器件 { get; set; }
        public string 散热检测 { get; set; }
        public string 触摸屏 { get; set; }
        public string 文本显示器 { get; set; }
        public string 信号指示灯 { get; set; }
        public string 安防系统 { get; set; }
        public string 巡检总结 { get; set; }
    }
}
