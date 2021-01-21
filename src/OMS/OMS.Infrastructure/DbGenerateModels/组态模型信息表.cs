using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 组态模型信息表
    {
        public int Id { get; set; }
        public string 模型名称 { get; set; }
        public int? 属性id { get; set; }
        public string Value { get; set; }
        public string 维度 { get; set; }
    }
}
