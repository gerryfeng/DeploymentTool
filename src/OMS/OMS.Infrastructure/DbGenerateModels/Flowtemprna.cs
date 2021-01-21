using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Flowtemprna
    {
        public int 流程id { get; set; }
        public int 节点id { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public string 节点名称 { get; set; }
        public string 正常图象 { get; set; }
        public string 反转图象 { get; set; }
        public int? 显示颜色 { get; set; }
        public decimal? 显示高度 { get; set; }
        public decimal? 显示宽度 { get; set; }
        public decimal? 字符尺寸 { get; set; }
        public byte[] 正常图象源 { get; set; }
        public byte[] 反转图象源 { get; set; }
        public int? 字体号 { get; set; }
        public decimal? 字体高 { get; set; }
        public decimal? 字体宽 { get; set; }
        public string 备注 { get; set; }
    }
}
