﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 报表视图子句配置表
    {
        public long Id { get; set; }
        public string 方案名 { get; set; }
        public string 视图名 { get; set; }
        public string 子句名 { get; set; }
        public string 条件名 { get; set; }
        public int? 参数序号 { get; set; }
        public string 表达式 { get; set; }
    }
}
