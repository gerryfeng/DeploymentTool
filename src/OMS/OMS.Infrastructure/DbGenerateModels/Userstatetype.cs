using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Userstatetype
    {
        public int Typeid { get; set; }
        public string Typename { get; set; }
        public int? Typeorder { get; set; }
        public int? Exist { get; set; }
    }
}
