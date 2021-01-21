using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class LayerRoleInfo
    {
        public int? LayerRoleId { get; set; }
        public string LayerRoleName { get; set; }
        public string Description { get; set; }
        public string Visible { get; set; }
    }
}
