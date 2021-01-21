using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolEquip
    {
        public int Id { get; set; }
        public string EquipType { get; set; }
        public string EquipEntities { get; set; }
        public int? Equiparea { get; set; }
        public string EquipPos { get; set; }
    }
}
