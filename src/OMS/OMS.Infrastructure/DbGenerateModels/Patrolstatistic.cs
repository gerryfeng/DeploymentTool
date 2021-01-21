using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Patrolstatistic
    {
        public int Id { get; set; }
        public int? 用户编号 { get; set; }
        public DateTime? 在线日期 { get; set; }
        public DateTime? 前一时间 { get; set; }
        public int? 在线时长 { get; set; }
        public int? 有效时长 { get; set; }
        public string 前一坐标 { get; set; }
        public int? 在线里程 { get; set; }
        public int? 有效里程 { get; set; }
        public int? 出圈次数 { get; set; }
        public DateTime? 登录时间 { get; set; }
        public DateTime? 登出时间 { get; set; }
    }
}
