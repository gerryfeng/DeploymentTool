﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单事件辅助视图配置表
    {
        public long Id { get; set; }
        public string 事件名称 { get; set; }
        public string 视图标签 { get; set; }
        public string 视图模块 { get; set; }
        public string 视图参数 { get; set; }
        public string 手持视图标签 { get; set; }
        public string 手持视图模块 { get; set; }
        public string 手持视图参数 { get; set; }
        public int? 显示顺序 { get; set; }
    }
}
