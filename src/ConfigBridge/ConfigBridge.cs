using ConfigBridge.ConnectionString;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ConfigBridge
{
    /// <summary>
    /// 获取运维解决方案及数据库配置信息
    /// </summary>
    public class ConfigBridge
    {
        public  string ConfCenterPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 解决方案名称
        /// </summary>
        public  App.configuration appconfiguration = new App.configuration();

        /// <summary>
        /// 连接字符串
        /// </summary>
        public  ConnectionString.configuration connConfig = new ConnectionString.configuration();

        public  OMSLoginConfig _loginConfig ;

        private static List<SubSystem> m_AllSubSystem = null;

        public static string WorkflowConnectionString = "";



        /// <summary>
        /// 获取ConfCenter路径
        /// </summary>
        /// <param name="isDev"></param>
        public ConfigBridge(bool isDev = false)
        {
            if (isDev)
            {
                ConfCenterPath = Path.Combine(ConfCenterPath, @"..\..\..\..\..\..\..\ConfCenter");
            }
            else
            {
                ConfCenterPath = Path.Combine(ConfCenterPath, @"..\..\ConfCenter");
            }
        }

        /// <summary>
        /// 获取ConfCenter上级目录
        /// </summary>
        /// <param name="isDev"></param>
        /// <param name="fileName">默认是CityTemp路径</param>
        /// <returns></returns>
        public static string CityTempPath(bool isDev = false, string fileName = "CityTemp")
        {
            if (isDev)
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"..\..\..\..\..\..\..\{fileName}");
            }
            else
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"..\..\{fileName}");
            }
        }

        /// <summary>
        /// 数据库中有此角色的用户可以登录运维管理系统
        /// </summary>
        public static string OMSRole = "运维管理登录权限";

        /// <summary>
        /// 解决方案路径
        /// </summary>
        public  string AppSolutionPath
        {
            get { return Path.Combine(ConfCenterPath, appconfiguration.solutionname); }
        }

        /// <summary>
        /// OMS路径
        /// </summary>
        public string OMSPath
        {
            get
            {
                return AppSolutionPath + @"\OMS\";
            }
        }

        public string RootPath
        {
            get { return Path.Combine(ConfCenterPath, $@"..\"); }
        }

        public string CityTempSolutionPath
        {
            get { return Path.Combine(RootPath, appconfiguration.solutionname); }
        }

        public string MapLayerPath
        {
            get { return Path.Combine(AppSolutionPath + @"\MapLayer.json"); }
        }

        /// <summary>
        /// 所有子系统集合
        /// </summary>
        public List<SubSystem> AllSubSystem
        {
            get
            {
                if (m_AllSubSystem == null)
                {
                    RefreshAllSubSystem();
                }

                return m_AllSubSystem;
            }
        }

        public void RefreshAllSubSystem()
        {
            #region 维护AllSubSystem成员变量及AllSubSystem.txt
            m_AllSubSystem = GetAllSubSystemList();

            #region 根据配置文件修改Title和topTitle
            List<SubSystemConfigItem> configSystemList = new List<SubSystemConfigItem>();

            string oldStr = "";
            if (File.Exists(OMSPath + "AllSubSystem.txt"))
            {
                oldStr = File.ReadAllText(OMSPath + "AllSubSystem.txt");

                configSystemList = JsonConvert.DeserializeObject<List<SubSystemConfigItem>>(File.ReadAllText(OMSPath + "AllSubSystem.txt"));

                for (int i = 0; i < m_AllSubSystem.Count; i++)
                {
                    for (int j = 0; j < configSystemList.Count; j++)
                    {
                        if (m_AllSubSystem[i].value == configSystemList[j].value && m_AllSubSystem[i].folder == configSystemList[j].folder)
                        {
                            m_AllSubSystem[i].title = configSystemList[j].title;
                            m_AllSubSystem[i].topTitle = configSystemList[j].title;
                            break;
                        }
                    }
                }
            }
            #endregion

            #region 根据重名Title修改topTitle
            for (int i = 0; i < m_AllSubSystem.Count; i++)
            {
                bool existTitle = false;

                for (int j = 0; j < m_AllSubSystem.Count; j++)
                {
                    if (m_AllSubSystem[i].title == m_AllSubSystem[j].title && i != j)
                    {
                        existTitle = true;
                        break;
                    }
                }

                if (existTitle && !string.IsNullOrEmpty(m_AllSubSystem[i].folder))
                {
                    m_AllSubSystem[i].topTitle = m_AllSubSystem[i].title + "（" + m_AllSubSystem[i].folder + "）";
                }
            }
            #endregion

            configSystemList.Clear();
            for (int i = 0; i < m_AllSubSystem.Count; i++)
            {
                SubSystemConfigItem item = new SubSystemConfigItem();
                item.title = m_AllSubSystem[i].title;
                item.value = m_AllSubSystem[i].value;
                item.folder = m_AllSubSystem[i].folder;
                configSystemList.Add(item);
            }

            string newStr = JsonConvert.SerializeObject(configSystemList, Newtonsoft.Json.Formatting.Indented);

            if (newStr != oldStr)
                Utility.ToolSaveFile(OMSPath + "AllSubSystem.txt", CityTempSolutionPath);

            File.WriteAllText(OMSPath + "AllSubSystem.txt", JsonConvert.SerializeObject(configSystemList, Newtonsoft.Json.Formatting.Indented));
            #endregion

            #region 删除多余配置文件
            if (File.Exists(OMSPath + "AllDrawer.txt"))
            {
                Utility.ToolSaveFile(OMSPath + "AllDrawer.txt", CityTempSolutionPath);
                File.Delete(OMSPath + "AllDrawer.txt");
            }
            if (File.Exists(OMSPath + "subSystemLocation.txt"))
            {
                Utility.ToolSaveFile(OMSPath + "subSystemLocation.txt", CityTempSolutionPath);
                File.Delete(OMSPath + "subSystemLocation.txt");
            }
            #endregion
        }

        private List<SubSystem> GetAllSubSystemList()
        {
            List<SubSystem> systemList = new List<SubSystem>();

            string[] dir = Directory.GetDirectories(RootPath);

            for (int i = 0; i < dir.Length; i++)
            {
                #region webgis
                if (File.Exists(dir[i] + "\\preLogin.xml"))
                {
                    XmlDocument doc = new XmlDocument();

                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.IgnoreComments = true;
                    using (XmlReader reader = XmlReader.Create(dir[i] + "\\preLogin.xml", settings))
                    {
                        doc.Load(reader);
                    }

                    XmlNodeList basemapNodes = doc.SelectNodes(@"/configuration/clientappname");

                    string clientappname = "webgis";//默认值
                    string title = "";

                    if (basemapNodes != null && basemapNodes.Count > 0 && !string.IsNullOrEmpty(basemapNodes[0].InnerText))
                        clientappname = basemapNodes[0].InnerText;

                    if (clientappname == "webgis")
                        title = "WebGIS";
                    else if (clientappname == "dispatch")
                        title = "调度平台";
                    else
                        title = clientappname;

                    systemList.Add(new SubSystem(title, clientappname, "webgis", dir[i]));
                }
                #endregion
            }

            for (int i = 0; i < dir.Length; i++)
            {
                #region 业务系统
                if (File.Exists(dir[i] + "\\Framework\\global.js"))
                {
                    List<string> configJSContent = new List<string>();
                    List<string> globalJSContent = File.ReadAllLines(dir[i] + "\\Framework\\global.js", Encoding.UTF8).ToList();
                    string configJSFilePath = "";
                    foreach (string globalLine in globalJSContent)
                    {
                        if (globalLine.Contains("projectFolder:") && globalLine.Trim(' ').Substring(0, 2) != @"//")
                        {
                            configJSFilePath = globalLine.Substring(globalLine.IndexOf('\"') + 3, globalLine.LastIndexOf('\"') - globalLine.IndexOf('\"') - 4).Replace("/", "\\");
                            break;
                        }
                    }

                    if (configJSFilePath != "" && File.Exists(dir[i] + "\\" + configJSFilePath + "\\config.js"))
                        configJSContent = File.ReadAllLines(dir[i] + "\\" + configJSFilePath + "\\config.js").ToList();

                    if (configJSContent.Count > 0)
                    {
                        string systemType = "业务系统"; //默认值
                        foreach (string configLine in configJSContent)
                        {
                            if (configLine.Contains("systemType:"))
                            {
                                systemType = configLine.Substring(configLine.IndexOf("\"") + 1, configLine.LastIndexOf("\"") - configLine.IndexOf("\"") - 1);
                                break;
                            }
                        }
                        systemList.Add(new SubSystem(systemType, systemType, "patrol", dir[i]));
                    }
                    else
                    {
                        systemList.Add(new SubSystem("业务系统", "业务系统", "patrol", dir[i]));
                    }
                }
                #endregion
            }

            systemList.Add(new SubSystem("手持系统", "手持系统", "mobile", ""));
            systemList.Add(new SubSystem("CS", "CS", "CS", ""));
            systemList.Add(new SubSystem("运维管理", "运维管理", "运维管理", ""));
            systemList.Add(new SubSystem("所有系统", "all", "all", ""));

            return systemList;
        }

        public OMSLoginConfig LoginConfig
        {
            get
            {
                if (_loginConfig == null)
                {
                    DeserializeConnConfig();
                    RefreshBasicConfig();
                }

                return _loginConfig;
            }
        }

        public XmlDocument GetWebXml()
        {
            DeserializeConnConfig();
            string file = Path.Combine(AppSolutionPath, "Web4Config.xml");

            XmlDocument doc = new XmlDocument();

            if (File.Exists(file))
            {
                XmlReaderSettings settings = new XmlReaderSettings
                {
                    IgnoreComments = true
                };
                using (XmlReader reader = XmlReader.Create(file, settings))
                {
                    doc.Load(reader);
                }
            }
            return doc;
        }

        public configuration DeserializeConnConfig()
        {
            //获取解决方案
            string AppPath = Path.Combine(ConfCenterPath,"app.xml");
            using (StreamReader r = new StreamReader(AppPath))
            {
                string xml = r.ReadToEnd();
                XmlSerializer serializer = new XmlSerializer(typeof(App.configuration));
                using (StringReader reader = new StringReader(xml))
                {
                    appconfiguration = (App.configuration)serializer.Deserialize(reader);
                }
            }
            
            //获取解决方案对应的数据库配置
            string path = Path.Combine(ConfCenterPath, string.IsNullOrEmpty(appconfiguration.solutionname)? "熊猫智慧水务平台" : appconfiguration.solutionname + @"\ConnectionString.xml");
            using (StreamReader r = new StreamReader(path))
            {
                string xml = r.ReadToEnd();
                XmlSerializer serializer = new XmlSerializer(typeof(ConnectionString.configuration));
                using (StringReader reader = new StringReader(xml))
                {
                     connConfig = (ConnectionString.configuration)serializer.Deserialize(reader);
                    WorkflowConnectionString = connConfig.workflow.Value;
                    return connConfig;
                }
            }
        }

        /// <summary>
        /// 维护basicConfig成员变量及OMSConfig.txt
        /// </summary>
        public  void RefreshBasicConfig()
        {
            string omsLoginUrl = Path.Combine(AppSolutionPath, @"OMS\OMSConfig.txt");

            if (!File.Exists(omsLoginUrl))
            {
                _loginConfig = new OMSLoginConfig();
                File.WriteAllText(omsLoginUrl, JsonConvert.SerializeObject(_loginConfig, Newtonsoft.Json.Formatting.Indented));
            }
            else
            {
                _loginConfig = JsonConvert.DeserializeObject<OMSLoginConfig>(File.ReadAllText(omsLoginUrl));
            }
        }
    }
}

//解决方案
namespace ConfigBridge.App 
{

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class configuration
    {
        public string solutionname { get; set; }
    }
}

namespace ConfigBridge.ConnectionString 
{ 
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class configuration
    {
        public configurationScada scada { get; set; }

        public configurationWorkflow workflow { get; set; }

        public configurationIotserver iotserver { get; set; }

        public configurationGdb gdb { get; set; }

        public configurationPatrol patrol { get; set; }

        public configurationMongo mongo { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationScada
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dbtype { get; set; }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationWorkflow
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dbtype { get; set; }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationIotserver
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dbtype { get; set; }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationGdb
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dbtype { get; set; }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationPatrol
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dbtype { get; set; }
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationMongo
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dbtype { get; set; }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }
}
