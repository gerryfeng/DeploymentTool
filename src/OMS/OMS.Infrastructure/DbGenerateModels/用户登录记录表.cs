using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 用户登录记录表
    {
        public int Id { get; set; }
        public string 用户登录名 { get; set; }
        public string 用户名 { get; set; }
        public string 系统类型 { get; set; }
        public string 终端 { get; set; }
        public string Ip { get; set; }
        public DateTime? 登录时间 { get; set; }
    }
}
