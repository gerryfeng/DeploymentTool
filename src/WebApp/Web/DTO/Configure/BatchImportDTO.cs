using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{

    /// <summary>
    /// 批量导入Dto
    /// </summary>
    public class BatchImportDTO
    {

        [Required]
        public string Type { get; set; }

        /// <summary>
        /// 维度
        /// </summary>
       [Required]
       public string Dimonsion { get; set; }

        /// <summary>
        /// 文件集合
        /// </summary>
        [Display(Name = "files")]
        public ICollection<IFormFile> files { get; set; }


    }
}
