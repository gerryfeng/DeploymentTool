using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PointAddress
    {
        public int Id { get; set; }
        public string Fversion { get; set; }
        public string Fname { get; set; }
        public string FstartAddress { get; set; }
        public int? FaddressLength { get; set; }
        public string Fnote { get; set; }
        public DateTime? FcreateDate { get; set; }
        public int? ForderBy { get; set; }
        public int? FisDelete { get; set; }
        public int? FupdUser { get; set; }
        public DateTime? FupdDate { get; set; }
        public int? FdelUser { get; set; }
        public DateTime? FdelDate { get; set; }
        public string FcreateUser { get; set; }
        public string Ftype { get; set; }
        public int? FisBaseScheme { get; set; }
        public int? 脚本启用 { get; set; }
        public string 脚本语言 { get; set; }
        public string 脚本内容 { get; set; }
        public string 分组名称 { get; set; }
        public int? 转存周期 { get; set; }
    }
}
