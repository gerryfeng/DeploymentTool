﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolmanWorktime
    {
        public int Id { get; set; }
        public DateTime? Wstarttime { get; set; }
        public DateTime? Wendtime { get; set; }
        public int? Flag { get; set; }
    }
}
