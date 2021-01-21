using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace ConfigBridge.DBHelper
{
    public class ConnectionStringManager
    {
        private static Dictionary<string, ConnectionItem> connStringDic = LoadDic();

        private static Dictionary<string, ConnectionItem> LoadDic()
        {
            Dictionary<string, ConnectionItem> dic = new Dictionary<string, ConnectionItem>();

            #region 从本地取
            string connFilePath = "";//AppHome.ConfigCenter + @"\" + AppConfigXml.SolutionName + @"\ConnectionString.xml";

            if (!File.Exists(connFilePath))
            {
                throw new Exception("数据库配置文件不存在：" + connFilePath);
            }

            XDocument docx = null;

            try
            {
                docx = XDocument.Load(connFilePath);
            }
            catch (Exception e)
            {
                throw new Exception("数据库配置文件加载失败，文件是：" + connFilePath + "，错误信息是：" + e.Message);
            }

            foreach (XElement xmlEle in docx.Root.Elements())
            {
                ConnectionItem item = new ConnectionItem();
                item.connString = xmlEle.Value;
                item.dbType = xmlEle.FirstAttribute.Value;

                if (!dic.ContainsKey(xmlEle.Name.LocalName))
                    dic.Add(xmlEle.Name.LocalName, item);
            }

            return dic;
            #endregion           
        }

        public static string WorkflowConnectionString
        {
            get
            {
                return connStringDic["workflow"].connString;
            }
        }

        public static string WorkflowDbType
        {
            get
            {
                return connStringDic["workflow"].dbType;
            }
        }

        public static string GDBConnectionString
        {
            get
            {
                return connStringDic["gdb"].connString;
            }
        }

        public static string GDBDbType
        {
            get
            {
                return connStringDic["gdb"].dbType;
            }
        }

        public static string SCADAConnectionString
        {
            get
            {
                return connStringDic["scada"].connString;
            }
        }

        // edit by zhangyao on 2019/07/17 滦州南京远传mysql
        public static string NJYCMYSQLConnectionString
        {
            get
            {
                return connStringDic["njyc_mysql"].connString;
            }
        }

        public static string SCADADbType
        {
            get
            {
                return connStringDic["scada"].dbType;
            }
        }

        public static string PostgresSqlConnectionString
        {
            get
            {
                return connStringDic["PostgresSql"].connString;
            }
        }

        public static string PostgresSqlDbType
        {
            get
            {
                return connStringDic["PostgresSql"].dbType;
            }
        }

        public static string PatrolConnectionString
        {
            get
            {
                return connStringDic["patrol"].connString;
            }
        }

        public static string PatrolDbType
        {
            get
            {
                return connStringDic["patrol"].dbType;
            }
        }

        public static string MongoConnectionString
        {
            get
            {
                try
                {
                    return connStringDic["mongo"].connString.Replace(";", "&");
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string MainServerUrl
        {
            get
            {
                try
                {
                    return connStringDic["mainserver"].connString;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string GetConnString(string name)
        {
            foreach (var kv in connStringDic)
            {
                if (kv.Key.ToLower() == name.ToLower())
                    return kv.Value.connString;
            }

            return "";
        }

        public static string GetDbType(string name)
        {
            foreach (var kv in connStringDic)
            {
                if (kv.Key.ToLower() == name.ToLower())
                    return kv.Value.dbType;
            }

            return "";
        }

        public static Dictionary<string, ConnectionItem> GetConnDic()
        {
            return connStringDic;
        }

        public static void ReLoad()
        {
            connStringDic = LoadDic();
        }
    }

    public class ConnectionItem
    {
        public string connString;
        public string dbType;
    }
}
