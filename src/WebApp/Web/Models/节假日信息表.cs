using System;

namespace Web.Models
{
    public partial class 节假日信息表
    {
        public int Id { get; set; }
        public DateTime 日期 { get; set; }
        public bool 是否节假日 { get; set; }
        public string 节假日类型 { get; set; }
    }
}
