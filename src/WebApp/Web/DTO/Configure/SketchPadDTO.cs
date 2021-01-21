using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class SketchPadDTO
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Dimonsion { get; set; }

        public string Camera { get; set; }

        public string DeployURL { get; set; }

        public string PointVersion { get; set; }

        public bool? IsTemplate { get; set; }

        public int Num { get; set; }

        public string ThumbnailURL { get; set; }

        public string ThreeDimonsionName { get; set; }

        public int IsDelete { get; set; }

        public string SiteCode { get; set; }

        public string SiteInfo { get; set; }

        public int TypeID { get; set; }
    }
}
