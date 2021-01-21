using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivDma用户台账表
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string 用户名称 { get; set; }
        public string 小区名称 { get; set; }
        public string 详细地址 { get; set; }
        public string 坐标位置 { get; set; }
        public string 用户类型 { get; set; }
        public string 营业区域 { get; set; }
        public string 用户状态 { get; set; }
        public string 联系人 { get; set; }
        public string 联系方式 { get; set; }
        public string 备注 { get; set; }
        public int? 是否删除 { get; set; }
        public string 用水类别 { get; set; }
        public string 水价类别 { get; set; }
        public string 表册 { get; set; }
        public string 一卡通号 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public string 联系人电话 { get; set; }
        public string GisCode { get; set; }
    }
}
