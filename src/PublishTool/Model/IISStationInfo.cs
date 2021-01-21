using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishTool
{
    /// <summary>
    /// IIS站点数据封装
    /// </summary>
    public class IISStationInfo
    {
        /// <summary>
        /// 站点名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 站点指定路径
        /// </summary>
        public string Path { get; set; }


        /// <summary>
        /// 站点标识符
        /// </summary>
        public long ID { get; set; }


        /// <summary>
        /// 站点包含的应用程序，虚拟路径等
        /// </summary>
        public List<IISAppInfo> AppList { get; set; }


    }


    /// <summary>
    /// IIS应用程序子站点数据封装
    /// </summary>
    public class IISAppInfo
    {


        /// <summary>
        /// 站点
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 站点的制定路径
        /// </summary>
        public string Path { get; set; }


        /// <summary>
        /// 站点的站点标识符
        /// </summary>
        public string ID { get; set; }


        /// <summary>
        /// 站点的应用程序名称
        /// </summary>
        public string AppName { get; set; }
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
