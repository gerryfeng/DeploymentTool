using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Scada远程控制权限配置更新日志
    {
        public int Id { get; set; }
        public string 配置编码 { get; set; }
        public string 初始配置 { get; set; }
        public string 修改配置 { get; set; }
        public string 操作人 { get; set; }
        public DateTime? 操作时间 { get; set; }
    }
}
