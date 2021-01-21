using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Flowdoingcase
    {
        public int Id0 { get; set; }
        public string 案件编号 { get; set; }
        public string 案件名称 { get; set; }
        public string 流程名称 { get; set; }
        public int 流程id { get; set; }
        public string 活动名称 { get; set; }
        public int 活动id { get; set; }
        public string 承办人 { get; set; }
        public int 承办人id { get; set; }
        public int 主承办人id { get; set; }
        public string 承办意见 { get; set; }
        public DateTime? 承办时间 { get; set; }
        public decimal? 延迟时间 { get; set; }
        public string 备注 { get; set; }
        public string 案件状态 { get; set; }
        public string 前活动 { get; set; }
        public string 前承办人 { get; set; }
        public int 移交方向 { get; set; }
        public decimal? 活动时限 { get; set; }
        public decimal? 剩余时限 { get; set; }
        public int 绑定案件个数 { get; set; }
    }
}
