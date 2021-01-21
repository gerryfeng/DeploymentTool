using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Scada远程控制控制权限配置表
    {
        public int Id { get; set; }
        public string 编码 { get; set; }
        public string 权限说明 { get; set; }
        public string 设备编码 { get; set; }
        public string 控制点位 { get; set; }
        public int? 控制人员 { get; set; }
        public int? 控制角色 { get; set; }
        public string 控制口令 { get; set; }
        public int? 开启身份验证 { get; set; }
        public int? 是否启用 { get; set; }
        public string 创建人 { get; set; }
        public DateTime? 创建时间 { get; set; }
        public string 修改人 { get; set; }
        public DateTime? 修改时间 { get; set; }
    }
}
