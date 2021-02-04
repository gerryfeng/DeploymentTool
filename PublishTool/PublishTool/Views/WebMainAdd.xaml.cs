using Microsoft.Web.Administration;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = Microsoft.Web.Administration.Application;

namespace PublishTool.Views
{
    /// <summary>
    /// WebMainAdd.xaml 的交互逻辑
    /// </summary>
    public partial class WebMainAdd : Page
    {
        List<Task> tasks = new List<Task>();
        public string siteType;
        public string directoryStr;
        private string[] apps;
        private static ServerManager manager;
        private List<GitPackage> gitPackages;
        public WebMainAdd(string args)
        {
            if (!string.IsNullOrEmpty(args))
            {
                siteType = args;
            }
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            type.Text = siteType;
            if (siteType == "IIS")
            {
                Title.Content = "IIS";
                var ImageUrl = "../Images/ICON/IIS.png";
                TitleImg.Source = new BitmapImage(new Uri(ImageUrl, UriKind.Relative));
            }
            else if (siteType == "WL")
            {
                Title.Content = "物联平台";
                var ImageUrl = "../Images/ICON/物联平台.png";
                TitleImg.Source = new BitmapImage(new Uri(ImageUrl, UriKind.Relative));
            }
            else if (siteType == "Panda")
            {
                Title.Content = "PandaGis";
                var ImageUrl = "../Images/ICON/pandagis.png";
                TitleImg.Source = new BitmapImage(new Uri(ImageUrl, UriKind.Relative));
            }
            else
            {
                Title.Content = "GeoServer";
                var ImageUrl = "../Images/ICON/geoserver.png";
                TitleImg.Source = new BitmapImage(new Uri(ImageUrl, UriKind.Relative));
            }

            //初始化加载数据
            GetConfigJson();
            manager = new ServerManager();
        }
        private void btn_FileClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  //选择文件夹


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//注意，此处一定要手动引入System.Window.Forms空间，否则你如果使用默认的DialogResult会发现没有OK属性
            {
                Filepath.Text = openFileDialog.SelectedPath;
                directoryStr = openFileDialog.SelectedPath + gitPackages.Find(x => x.PackageName.Equals("Publish")).StoragePath;
            }
        }
        private void btn_QuiteClick(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            NavigationService.GetNavigationService(this).Navigate(home);
        }

        private void GetConfigJson()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "config.json";
            JsonConfigHelper helper = new JsonConfigHelper(configPath);
            gitPackages = helper.GetValue<List<GitPackage>>("GitPackages");
            apps = helper.GetValue<string[]>("CoreApp");

        }

        private void btn_SaveClick(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var configPath = AppDomain.CurrentDomain.BaseDirectory + "config.json";
                JsonConfigHelper helper = new JsonConfigHelper(configPath);
                siteName.IsEnabled = false;
                Filepath.IsEnabled = false;
                ipAddress.IsEnabled = false;
                port.IsEnabled = false;
                isUseWg.IsEnabled = false;
                var gitPackages = helper.GetValue<List<GitPackage>>("GitPackages");
                var filePath = this.Filepath.Text;
                var directoryStr = filePath + gitPackages.Find(x => x.PackageName.Equals("Publish")).StoragePath;
                if (string.IsNullOrEmpty(filePath))
                {
                    showMessageWinDow("部署服务前请选择文件路径");
                }
                else
                {
                    MainClon(directoryStr, gitPackages);
                }
            }
            else
            {
                showMessageWinDow("保存失败,请检查基本信息以及端口号是否重复！");
            }
        }

        public void showMessageWinDow(string Msg)
        {
            MessageWindow messageWindow = new MessageWindow(Msg);
            messageWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            messageWindow.ShowDialog();
        }
        private bool Validate()
        {
            var flag = true;
            GetParamSetting getParamSetting = new GetParamSetting();
            var siteList = getParamSetting.GetParamData();
            if (string.IsNullOrEmpty(siteName.Text) || string.IsNullOrEmpty(port.Text) || string.IsNullOrEmpty(ipAddress.Text))
            {
                flag = false;
            }
            var data = siteList.Find(x => x.SiteName == siteName.Text || x.Port == port.Text);
            if (data != null)
            {
                flag = false;
            }
            var mndata = manager.Sites;
            foreach (var s in mndata)
            {
                if (s.Name.Equals(siteName.Text))
                {
                    flag = false;
                    break;
                }
                if (!s.Name.Equals("Default Web Site"))
                {
                   
                    foreach (var tmp in s.Bindings)
                    {
                        if (tmp.EndPoint.Port.ToString().Equals(port.Text))
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            return flag;
        }
        private async void MainClon(string directoryStr, List<GitPackage> gitPackages)
        {
            TaskCallBack += Accomplish;
            WriteHelp.IsExistDirectory(directoryStr);
            lodingGrid.Visibility = Visibility.Visible;
            foreach (var item in gitPackages)
            {
                //if (item.PackageName == "Publish")
                //{
                var path = this.Filepath.Text + item.StoragePath;
                tasks.Add(Task.Run(() => clone(path, " clone " + item.DownloadURL, item.PackageName)));
                //}

            }
            await Task.WhenAll(tasks);
            TaskCallBack();
        }
        private AccomplishTask TaskCallBack;
        private delegate void AccomplishTask();
        private void Accomplish()
        {
            //还可以进行其他的一些完任务完成之后的逻辑处理
            tasks.Clear();
            GetParamSetting getParamSetting = new GetParamSetting();
            var WebSiteInfo = new WebSiteInfo();
            WebSiteInfo.SiteName = siteName.Text;
            if (type.Text == "IIS")
            {
                WebSiteInfo.EnvironmentInfo = "IIS本地部署";
                WebSiteInfo.Tag = "IIS";
            }
            else if (type.Text == "物联平台")
            {
                WebSiteInfo.EnvironmentInfo = "物联平台部署";
                WebSiteInfo.Tag = "物联平台";
            }
            else if (type.Text == "PandaGis")
            {
                WebSiteInfo.EnvironmentInfo = "PandaGis部署";
                WebSiteInfo.Tag = "PandaGis";
            }
            else
            {
                WebSiteInfo.EnvironmentInfo = "GeoServer部署";
                WebSiteInfo.Tag = "GeoServer";
            }
            WebSiteInfo.Path = Filepath.Text;
            WebSiteInfo.Ip = ipAddress.Text;
            WebSiteInfo.Port = port.Text;
            WebSiteInfo.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            WebSiteInfo.IsOpenWg = isUseWg.IsChecked == true ? "1" : "0";
            getParamSetting.Save(WebSiteInfo);
            //发布
            Publish();
            showMessageWinDow("添加成功");
            Home home = new Home();
            NavigationService.GetNavigationService(this).Navigate(home);

        }

        private void Publish()
        {
            var ip = ipAddress.Text;
            var Port = port.Text;
            var SiteName = siteName.Text;
            if (string.IsNullOrWhiteSpace(directoryStr))
            {
                return;
            }
            setConfiguration(ip, Port);
            try
            {
                CreateSite(SiteName, ip, Convert.ToInt32(Port), directoryStr);
            }
            catch (Exception)
            {
                showMessageWinDow("发布网站失败");
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
        public void setConfiguration(string ip, string port)
        {
            ip = ip.Equals("*") ? "localhost" : ip;
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
        private void clone(string initPath, string cloneUrl, string package)
        {
            try
            {

                var git = new CommandRunner("git", initPath);

                string logs = git.Run(cloneUrl);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("获取" + package + "包异常" + ex.StackTrace);
            }

        }

    }
}
