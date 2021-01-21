using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 组态画板类型表
    {
        public int Id { get; set; }
        public string 名称 { get; set; }
        public string RoleCode { get; set; }
        public DateTime? 创建时间 { get; set; }
    }
}
