using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigBridge
{
    public class OMSPath
    {

        public static string ConfCenterPath = "";
        public static string SoluntionName = "";

        public static void Init( string confPath,string soluntionName)
        {
            ConfCenterPath = confPath;
            SoluntionName = soluntionName;
        }


        /// <summary>
        /// 运维配置文件目录
        /// </summary>
        public static string pathOMSConfig
        {
            get
            {
                return $@"{ConfCenterPath}\{SoluntionName}\OMS\";
            }
        }

        /// <summary>
        /// 解决方案排除文件
        /// </summary>
        public static List<string> solutionNameExclusionList = new List<string>() {
            "BufFile",
            "CityInterface",
            "OMS",
            "Projects",
            ".git",
            "MeterCare",
            "Nginx",
            "ProductCenter",
            "NetCoreConfigs"
        };
    }
}
