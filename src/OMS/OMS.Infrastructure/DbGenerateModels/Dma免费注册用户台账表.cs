using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Dma免费注册用户台账表
    {
        public int Id { get; set; }
        public string 编码 { get; set; }
        public string 户表名称 { get; set; }
        public string 用户名称 { get; set; }
        public string 分区编码 { get; set; }
        public string 抄表年月 { get; set; }
        public double? 上期表码 { get; set; }
        public double? 本期表码 { get; set; }
        public double? 用水量 { get; set; }
        public DateTime? 抄表日期 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int 是否删除 { get; set; }
    }
}
