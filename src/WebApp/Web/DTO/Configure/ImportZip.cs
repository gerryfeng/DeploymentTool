using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Configure
{
    public class ImportZip
    {

        [Required]
        public string siteCode { get; set; }

        public IFormFile file { get; set; }

    }
}
