using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolPhone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneUsed { get; set; }
        public string PhoneFactory { get; set; }
        public string PhoneModel { get; set; }
        public string Remark { get; set; }
    }
}
