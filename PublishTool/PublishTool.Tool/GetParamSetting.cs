using PublishTool.Tool.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PublishTool.Tool
{
    public class GetParamSetting
    {
        public static List<WebSiteInfo> pubList;
        public List<WebSiteInfo> GetParamData()
        {
            string fileName = Path.ChangeExtension("PublishTool", ".config");
            string jsonString = "";
            try
            {
                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {
                    //读取文件
                    jsonString = sr.ReadToEnd();
                }
            }
            catch
            {
                fileName = AppDomain.CurrentDomain.BaseDirectory + "PublishTool.config";
                try
                {
                    using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                    {
                        //读取文件
                        jsonString = sr.ReadToEnd();
                    }
                }
                catch (Exception)
                {

                }
            }
            List<WebSiteInfo> List = new List<WebSiteInfo>();
            JsonObject jo = JsonObject.Parse(jsonString.Replace("\\", "\\\\"));
            JsonProperty jpMessageCon = jo["Site"];
            if (jpMessageCon.HasProperty("Items"))
            {
                JsonProperty jpMessageItems = jpMessageCon["Items"];
                if (jpMessageItems.IsArray)
                {
                    foreach (JsonProperty jpMessageItem in jpMessageItems)
                    {
                        WebSiteInfo webSiteInfo = new WebSiteInfo()
                        {
                            SiteName = jpMessageItem["SiteName"],
                            EnvironmentInfo = jpMessageItem["EnvironmentInfo"],
                            Path = jpMessageItem["Path"],
                            Date = jpMessageItem["Date"],
                            Ip = jpMessageItem["Ip"],
                            Port = jpMessageItem["Port"],
                            Tag = jpMessageItem["Tag"],
                            IsOpenWg = jpMessageItem["IsOpenWg"]

                        };
                        webSiteInfo.StateImg = "/Images/ICON/绿灯.png";
                        if (jpMessageItem["Tag"] == "IIS")
                        {
                            webSiteInfo.ImageUrl = "/Images/ICON/IIS.png";
                            List.Add(webSiteInfo);
                        }
                        else if (jpMessageItem["Tag"] == "物联平台")
                        {
                            webSiteInfo.ImageUrl = "/Images/ICON/物联平台.png";
                            List.Add(webSiteInfo);
                        }
                        else if (jpMessageItem["Tag"] == "PandaGis")
                        {
                            webSiteInfo.ImageUrl = "/Images/ICON/pandagis.png";
                            List.Add(webSiteInfo);
                        }
                        else
                        {
                            webSiteInfo.ImageUrl = "/Images/ICON/geoserver.png";
                            List.Add(webSiteInfo);
                        }
                    }
                }
            }
            pubList = List;
            return List;
        }

        public void Save(WebSiteInfo webSiteInfo)
        {
            var flag = true;
            if (pubList.Count < 1)
            {
                pubList= GetParamData();
            }
            if (webSiteInfo != null)
            {
                foreach (var item in pubList)
                {
                    if (item.SiteName == webSiteInfo.SiteName)
                    {
                        flag = false;
                        item.Ip = webSiteInfo.Ip;
                        item.Port = webSiteInfo.Port;
                        item.Path = webSiteInfo.Path;
                        item.Date = webSiteInfo.Date;
                        item.IsOpenWg = webSiteInfo.IsOpenWg;
                    }
                }
            }
            if (flag)
            {
                pubList.Add(webSiteInfo);
            }
            JsonObject jo = new JsonObject();
            foreach (var item in pubList)
            {
                JsonProperty jpMessageConnItem = new JsonProperty();
                jpMessageConnItem["SiteName"] = item.SiteName;
                jpMessageConnItem["EnvironmentInfo"] = item.EnvironmentInfo;
                jpMessageConnItem["Path"] = item.Path;
                jpMessageConnItem["Date"] = item.Date;
                jpMessageConnItem["Ip"] = item.Ip;
                jpMessageConnItem["Port"] = item.Port;
                jpMessageConnItem["Tag"] = item.Tag;
                jpMessageConnItem["IsOpenWg"] = item.IsOpenWg;
                jo["Site"]["Items"].Add(jpMessageConnItem);
            }
            var processModule = Process.GetCurrentProcess().MainModule;
            if (processModule == null) return;
            string fileName = Path.ChangeExtension(processModule.FileName, ".config");
            string jsonString = jo.ToString();

            // 为防止占用, 重试 10s
            int retryCount = 0;
            while (retryCount++ < 10)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                    {
                        sw.Write(jsonString);
                    }

                    break;
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }

        }
    }
}
