using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 组态模型类型表
    {
        public int Id { get; set; }
        public string 类型名称 { get; set; }
        public string 创建人 { get; set; }
        public DateTime? 创建日期 { get; set; }
    }
}
