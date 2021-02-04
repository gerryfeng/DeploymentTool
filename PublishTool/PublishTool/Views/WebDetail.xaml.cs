﻿using Microsoft.Web.Administration;
using Newtonsoft.Json;
using PublishTool.Tool;
using PublishTool.Tool.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = Microsoft.Web.Administration.Application;

namespace PublishTool.Views
{
    /// <summary>
    /// WebDetail.xaml 的交互逻辑
    /// </summary>
    public partial class WebDetail : Page
    {
        public string PubsiteName;
        public string siteType;
        private static ServerManager manager;
        private List<GitPackage> gitPackages;
        private string[] apps;
        public WebDetail(string siteName, string type)
        {
            InitializeComponent();
            PubsiteName = siteName;
            siteType = type;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetParamSetting getParamSetting = new GetParamSetting();
            var dataList = getParamSetting.GetParamData();
            var data = dataList.Find(x => x.SiteName == PubsiteName);
            if (data != null)
            {
                manager = new ServerManager();
                string configPath = AppDomain.CurrentDomain.BaseDirectory + "config.json";
                JsonConfigHelper helper = new JsonConfigHelper(configPath);
                gitPackages = helper.GetValue<List<GitPackage>>("GitPackages");
                apps = helper.GetValue<string[]>("CoreApp");
                if (data.IsOpenWg == "1")
                {
                    isUseWg.IsChecked = true;
                    isUseWg.Content = "是";
                }
                else
                {
                    isUseWg.IsChecked = false;
                    isUseWg.Content = "否";
                }
                this.siteName.Text = data.SiteName;
                this.ipAddress.Text = data.Ip;
                this.port.Text = data.Port;
                this.path.Content = data.Path;
                if (siteType == "IIS")
                {
                    title.Content = "IIS";
                    var ImageUrl = "../Images/ICON/IIS.png";
                    TitleImg.Source = new BitmapImage(new Uri(ImageUrl, UriKind.Relative));
                   
                }
                else if (siteType == "WL")
                {
                    title.Content = "物联平台";
                    var ImageUrl = "../Images/ICON/物联平台.png";
                    TitleImg.Source = new BitmapImage(new Uri(ImageUrl, UriKind.Relative));
                   
                }
                else if (siteType == "PandaGis")
                {
                    title.Content = "PandaGis";
                    var ImageUrl = "../Images/ICON/pandagis.png";
                    TitleImg.Source = new BitmapImage(new Uri(ImageUrl, UriKind.Relative));
                   
                }
                else
                {
                    title.Content = "GeoServer";
                    var ImageUrl = "../Images/ICON/geoserver.png";
                    TitleImg.Source = new BitmapImage(new Uri(ImageUrl, UriKind.Relative));
                }
            }
        }

        private void dataSave(object sender, RoutedEventArgs e)
        {
            var websiteInfo = new WebSiteInfo();
            websiteInfo.Ip = this.ipAddress.Text;
            websiteInfo.Port = this.port.Text;
            websiteInfo.Path = this.path.Content.ToString();
            websiteInfo.SiteName = this.siteName.Text;
            websiteInfo.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            websiteInfo.IsOpenWg = isUseWg.IsChecked == true ? "1" : "0";
            GetParamSetting getParamSetting = new GetParamSetting();
            var datalist = getParamSetting.GetParamData();
            var data = datalist.Find(x => x.Port == port.Text && x.SiteName != siteName.Text);
            if (data == null)
            {
                foreach (var s in manager.Sites)//遍历网站
                {
                    if (!s.Name.Equals("Default Web Site") && !s.Name.Equals(siteName.Text))
                    {
                        foreach (var tmp in s.Bindings)
                        {
                            if (tmp.EndPoint.Port.ToString().Equals(port.Text))
                            {
                                showMessageWinDow("端口号重复，保存失败");
                                return;
                            }
                        }
                    }
                }
                getParamSetting.Save(websiteInfo);
                ReStartWeb();
                showMessageWinDow("保存成功");

            }
            else
            {
                showMessageWinDow("端口号重复，保存失败");
            }
            
           
            //Home home = new Home();
            //NavigationService.GetNavigationService(this).Navigate(home);
        }

        public void showMessageWinDow(string Msg)
        {
            MessageWindow messageWindow = new MessageWindow(Msg);
            messageWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            messageWindow.ShowDialog();
        }
        public void setConfiguration(string ip, string port)
        {
            ip = ip.Equals("*") ? "localhost" : ip;
            var directoryStr= path.Content+ gitPackages.Find(x => x.PackageName.Equals("Publish")).StoragePath;
            string omsPath = directoryStr + "\\ConfCenter\\NetCoreConfigs\\OMS\\appsettings.json";
            string identityPath = directoryStr + "\\ConfCenter\\NetCoreConfigs\\Identity\\identity.json";
            string ocelotPath = directoryStr + "\\ConfCenter\\NetCoreConfigs\\GateWay\\ocelot.json";
            var IsGateWAY = isUseWg.IsChecked;
            try
            {
                string omsJson, identityJson, gateWayJson;
                #region 修改oms配置文件
                using (FileStream reader = File.Open(omsPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    int len = (int)reader.Length;
                    byte[] bytes = new byte[len];
                    reader.Read(bytes, 0, len);
                    dynamic jsonObj = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bytes));

                    string identiyUrl = jsonObj["AppSetting"].IdentityServerUrl.Value;
                    Uri omsUrl = new Uri(identiyUrl);
                    jsonObj["AppSetting"].IsGateWay.Value = IsGateWAY.ToString().ToLower();
                    jsonObj["AppSetting"].IdentityServerUrl.Value = $"http://{ip}:{port}{omsUrl.AbsolutePath}";
                    omsJson = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                }
                if (!string.IsNullOrWhiteSpace(omsJson))
                    File.WriteAllText(omsPath, omsJson);
                #endregion

                #region 修改授权配置文件
                using (FileStream reader = File.Open(identityPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    int len = (int)reader.Length;
                    byte[] bytes = new byte[len];
                    reader.Read(bytes, 0, len);
                    dynamic jsonObj = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bytes));

                    string identiyUrl = jsonObj["IdentityServer"].Clients[0].RedirectUris[0].Value;
                    Uri tUrl = new Uri(identiyUrl);

                    jsonObj["IdentityServer"].Clients[0].RedirectUris[0].Value = $"http://{ip}:{port}{tUrl.AbsolutePath}";
                    identityJson = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                }
                if (!string.IsNullOrWhiteSpace(identityJson))
                    File.WriteAllText(identityPath, identityJson);
                #endregion

                #region 修改网关配置文件
                using (FileStream reader = File.Open(ocelotPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    int len = (int)reader.Length;
                    byte[] bytes = new byte[len];
                    reader.Read(bytes, 0, len);
                    dynamic jsonObj = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bytes));

                    foreach (dynamic arr in jsonObj["Routes"])
                    {
                        arr.DownstreamHostAndPorts[0]["Host"] = ip;
                        arr.DownstreamHostAndPorts[0]["Port"] = port;
                    }
                    gateWayJson = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                }
                if (!string.IsNullOrWhiteSpace(gateWayJson))
                    File.WriteAllText(ocelotPath, gateWayJson);
                #endregion

            }
            catch (Exception)
            {
                showMessageWinDow("修改(oms/授权/网关)配置文件信息失败");
            }
        }

        public void ReStartWeb()
        {
            setConfiguration(ipAddress.Text, port.Text);
            var directoryStr = path.Content + gitPackages.Find(x => x.PackageName.Equals("Publish")).StoragePath;
            CreateSite(siteName.Text, ipAddress.Text, Convert.ToInt32(port.Text), directoryStr);
            List<ApplicationPool> poolCollection = manager.ApplicationPools.Where(s => s.Name.StartsWith(siteName.Text + "_")).ToList();
            foreach (ApplicationPool pool in poolCollection)
            {
                pool.Recycle();
            }
        }

        public static ApplicationPool FindApplicationPoolByName(string poolName)
        {
            ApplicationPoolCollection poolCollection = manager.ApplicationPools;
            foreach (ApplicationPool pool in poolCollection)
            {
                if (pool.Name.ToUpper() == poolName.ToUpper())
                {
                    return pool;
                }
            }
            return null;
        }
        public static bool IsWebsiteExists(string strWebsitename)
        {
            Site site = FindSiteBySiteName(strWebsitename);
            if (site == null)
                return false;
            else
                return true;
        }
        public static Site FindSiteBySiteName(string strWebsitename)
        {
            SiteCollection siteCollection = manager.Sites;
            foreach (Site site in siteCollection)
            {
                if (site.Name.ToUpper() == strWebsitename.ToUpper())
                {
                    return site;
                }
            }
            return null;
        }
        public static void CreateApplicationPool(string poolname, string runtimeVersion, bool enable32)
        {
            ApplicationPool newPool = manager.ApplicationPools.Add(poolname);
            newPool.ManagedRuntimeVersion = runtimeVersion;//.net framework运行版本
            newPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;//托管管道为集成模式  ManagedPipelineMode.Classic为经典模式
            newPool.AutoStart = true;//自动启动
            newPool.ProcessModel.IdentityType = ProcessModelIdentityType.LocalSystem;
            if (enable32)
            {
                newPool.Enable32BitAppOnWin64 = true;//允许32位应用程序运行在64位Windows上
            }
            manager.CommitChanges();
        }

        public static void CreateWebSite(string siteName, string ip, int port, string webPathstr)
        {
            if (ip.Equals("*"))
            {
                manager.Sites.Add(siteName, webPathstr, port);
            }
            else
            {
                manager.Sites.Add(siteName, "http", ip + ":" + port + ":", webPathstr);
            }


            manager.CommitChanges();
        }
        public static bool IsApplicationExists(Site site, string applicationName)
        {
            Application application = FindApplicationByName(site, applicationName);
            if (application == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Application FindApplicationByName(Site site, string applicationName)
        {
            Application application = site.Applications[applicationName];

            if (application != null)
            {
                return application;
            }

            return null;
        }
        public void CreateSite(string siteName, string ip, int port, string directory)
        {
            ApplicationPool pool = FindApplicationPoolByName(siteName);
            if (pool != null)
            {
                manager.ApplicationPools.Remove(pool);
            }

            if (IsWebsiteExists(siteName))
            {
                manager.Sites.Remove(manager.Sites[siteName]);
            }
            CreateApplicationPool(siteName, "v4.0", true);
            CreateWebSite(siteName, ip, port, directory);

            Site site = FindSiteBySiteName(siteName);
            ApplicationPool appPool = FindApplicationPoolByName(siteName);

            //site.Stop();
            //site.ApplicationDefaults.ApplicationPoolName = appPool.Name;
            site.Applications["/"].ApplicationPoolName = appPool.Name;

            DirectoryInfo theFolder = new DirectoryInfo(directory);
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            foreach (DirectoryInfo model in dirInfo)
            {
                if (model.Name.Equals("CityInterface"))
                {
                    if (!IsApplicationExists(site, "/" + model.Name))
                    {
                        site.Applications.Add("/" + model.Name, model.FullName);
                        site.Applications["/" + model.Name].ApplicationPoolName = appPool.Name;
                    }
                }

                if (model.Name.Equals("web4"))
                {
                    if (!IsApplicationExists(site, "/" + model.Name))
                    {
                        site.Applications.Add("/" + model.Name, model.FullName);
                        site.Applications["/" + model.Name].ApplicationPoolName = appPool.Name;
                    }
                }

                if (model.Name.Equals("CityOMS3"))
                {
                    if (!IsApplicationExists(site, "/" + model.Name))
                    {
                        site.Applications.Add("/" + model.Name, model.FullName);
                        site.Applications["/" + model.Name].ApplicationPoolName = appPool.Name;
                    }
                }

                if (model.Name.Equals("MobileGCK"))
                {
                    if (!IsApplicationExists(site, "/" + model.Name))
                    {
                        site.Applications.Add("/" + model.Name, model.FullName);
                        site.Applications["/" + model.Name].ApplicationPoolName = appPool.Name;
                    }
                }

                if (model.Name.Equals("civmanage"))
                {
                    if (!IsApplicationExists(site, "/" + model.Name))
                    {
                        site.Applications.Add("/" + model.Name, model.FullName);
                        site.Applications["/" + model.Name].ApplicationPoolName = appPool.Name;
                    }
                }

                if (model.Name.Equals("civweb4"))
                {
                    if (!IsApplicationExists(site, "/" + model.Name))
                    {
                        site.Applications.Add("/" + model.Name, model.FullName);
                        site.Applications["/" + model.Name].ApplicationPoolName = appPool.Name;
                    }
                }

                if (model.Name.Equals("civbase"))
                {
                    if (!IsApplicationExists(site, "/" + model.Name))
                    {
                        site.Applications.Add("/" + model.Name, model.FullName);
                        site.Applications["/" + model.Name].ApplicationPoolName = appPool.Name;
                    }
                }

                if (model.Name.Equals("Publish"))
                {
                    foreach (DirectoryInfo item in model.GetDirectories())
                    {
                        if (apps.Contains(item.Name))
                        {
                            if (!IsApplicationExists(site, "/Publish/" + item.Name))
                            {
                                site.Applications.Add("/Publish/" + item.Name, item.FullName);
                            }

                            if (!IsApplicationPoolExists(site.Name + "_" + item.Name))
                            {
                                CreateApplicationPool(manager, site.Name + "_" + item.Name, "", false);
                            }

                            site.Applications["/Publish/" + item.Name].ApplicationPoolName = site.Name + "_" + item.Name;
                        }

                    }
                }
            }

            manager.CommitChanges();
            //site.Start();
            appPool.Recycle();
        }
        public static void CreateApplicationPool(ServerManager mgr, string poolname, string runtimeVersion, bool enable32)
        {
            ApplicationPool newPool = mgr.ApplicationPools.Add(poolname);
            newPool.ManagedRuntimeVersion = runtimeVersion;//.net framework运行版本
            newPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;//托管管道为集成模式  ManagedPipelineMode.Classic为经典模式
            newPool.AutoStart = true;//自动启动
            if (enable32)
            {
                newPool.Enable32BitAppOnWin64 = true;//允许32位应用程序运行在64位Windows上
            }
        }
        public static bool IsApplicationPoolExists(string appPool)
        {
            ApplicationPool pool = FindApplicationPoolByName(appPool);
            if (pool == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void DataexChange(object sender, RoutedEventArgs e)
        {
            if (isUseWg.IsChecked == false)
            {
                isUseWg.Content = "否";
            }
            else
            {
                isUseWg.Content = "是";
            }
        }
    }
}
