using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishTool.Tool.Model
{
 public   class WebSiteInfo
    {
        public string SiteName { get; set; }

        public string EnvironmentInfo { get; set; }

        public string Path { get; set; }

        public string Date { get; set; }

        public string Ip { get; set; }

        public string Port { get; set; }
        public string Tag { get; set; }
        public string ImageUrl { get; set; }

        public string StateImg { get; set; }

        public string IsOpenWg { get; set; }
    }

    public class GitPackage
    {
        public string DisplayName { get; set; }
        public string PackageName { get; set; }
        public string DownloadURL { get; set; }
        public string StoragePath { get; set; }
        public bool IsDeploy { get; set; }
    }
}
