using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowUser
    {
        public int 用户id { get; set; }
        public string 名称 { get; set; }
        public string 工号 { get; set; }
        public string 备注 { get; set; }
        public string Password { get; set; }
        public int Indexorder { get; set; }
        public string Userimge { get; set; }
        public string Coordinate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public double? Tokenexpiration { get; set; }
        public string Ddid { get; set; }
        public string Wxid { get; set; }
        public string Mark { get; set; }
        public int? State { get; set; }
        public string 企业微信 { get; set; }
    }
}
