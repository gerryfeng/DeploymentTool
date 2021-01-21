using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class ModelTypeDTO
    {
        public int ID { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "类型名称")]
         public string Name { get; set; }

        public int NumBer { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "创建人")]
        public string People { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }

       


    }
}
