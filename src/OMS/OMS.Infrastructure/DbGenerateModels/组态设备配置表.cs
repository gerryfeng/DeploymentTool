using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 组态设备配置表
    {
        public int 画板id { get; set; }
        public int 画板设备key { get; set; }
        public string 模型名称 { get; set; }
        public string 大小xyz { get; set; }
        public string 坐标zyz { get; set; }
        public string 旋转角度xyz { get; set; }
        public string 传感器名称 { get; set; }
        public string 控制服务url { get; set; }
    }
}
