using Microsoft.Web.Administration;
using PublishTool.Common;
using PublishTool.Styles.Carousel;
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
using System.Windows.Navigation;

namespace PublishTool.Views
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        private static ServerManager manager;
        List<Task> tasks = new List<Task>();
        public bool showDio=false;
        public Home()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            manager = new ServerManager();
            List<WebSiteInfo> iisList = new List<WebSiteInfo>();
            List<WebSiteInfo> WlList = new List<WebSiteInfo>();
            List<WebSiteInfo> PandaList = new List<WebSiteInfo>();
            List<WebSiteInfo> GeoList = new List<WebSiteInfo>();
            GetParamSetting getParamSetting = new GetParamSetting();
            var dataList = getParamSetting.GetParamData();
            foreach (var item in dataList)
            {
                if (item.Tag== "IIS")
                {
                    iisList.Add(item);
                }else if (item.Tag == "物联平台")
                {
                    WlList.Add(item);
                }else if (item.Tag == "PandaGis")
                {
                    PandaList.Add(item);
                }
                else
                {
                    GeoList.Add(item);
                }
            }
                iisData.ItemsSource = iisList;
                wulianData.ItemsSource = WlList;
                pandaGisData.ItemsSource = PandaList;
                GeoServerData.ItemsSource = GeoList;
            
        }

        private AccomplishTask TaskCallBack;
        private delegate void AccomplishTask();

        private void Accomplish()
        {

            //还可以进行其他的一些完任务完成之后的逻辑处理
            tasks.Clear();
            if (showDio)
            {
                showMessageWinDow("更新成功");
                showDio = false;
            }
            lodingGrid.Visibility = Visibility.Hidden;
        }
        public void showMessageWinDow(string Msg)
        {
            MessageWindow messageWindow = new MessageWindow(Msg);
            messageWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            messageWindow.ShowDialog();
        }
        private void update_Click(object sender, RoutedEventArgs e) 
        {

            TaskCallBack += Accomplish;
            lodingGrid.Visibility = Visibility.Visible;
            Button btn = sender as Button;
            var siteName = btn.CommandParameter as string;
            MainPull(siteName);

        }

        private async void MainPull(string siteName) 
        {
            Site site = FindSiteBySiteName(siteName);
            string add = GetPhysicalPathBySite(site);
            showDio = true;
            tasks.Add(Task.Run(() => pull(add)));
            await Task.WhenAll(tasks);
            TaskCallBack();
        }
        private string GetPhysicalPathBySite(Site site)
        {
            var applicationRoot = site.Applications.Where(a => a.Path == "/").Single();
            var virtualRoot = applicationRoot.VirtualDirectories.Where(v => v.Path == "/").Single();
            string directory = virtualRoot.PhysicalPath;
            return directory;
        }
        private void pull(string initPath)
        {
            try
            {
                var git = new CommandRunner("git", initPath);

                string logs = git.Run("pull");
                //lodingGrid.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
              
            }

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
        private void Grid_MouseDown(object sender, RoutedEventArgs e)
        {
            Grid grid= sender as Grid;
            var websiteinfo = grid.DataContext as WebSiteInfo;
            var siteName = websiteinfo.SiteName;
            var tag = websiteinfo.Tag;
            WebDetail webDetail = new WebDetail(siteName, tag);
            NavigationService.GetNavigationService(this).Navigate(webDetail);
        }
        private void File_MouseDown(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var path = btn.CommandParameter as string;
            System.Diagnostics.Process.Start(path);
        }
        private void AddIISWeb_Click(object sender, RoutedEventArgs e)
        {
            WebMainAdd ul = new WebMainAdd("IIS");
            NavigationService.GetNavigationService(this).Navigate(ul);

        }
        private void AddWlWeb_Click(object sender, RoutedEventArgs e)
        {
            WebMainAdd ul = new WebMainAdd("WL");
            NavigationService.GetNavigationService(this).Navigate(ul);

        }
        private void AddPandaWeb_Click(object sender, RoutedEventArgs e)
        {
            WebMainAdd ul = new WebMainAdd("Panda");
            NavigationService.GetNavigationService(this).Navigate(ul);

        }
        private void AddGeoWeb_Click(object sender, RoutedEventArgs e)
        {
            WebMainAdd ul = new WebMainAdd("Geo");
            NavigationService.GetNavigationService(this).Navigate(ul);

        }


        public void View_OnReturn()
        {
            //this.Homes.Children.Clear();

            //CurNavPage = new NavPage();
            //CurNavPage.OnSelectChanged += PageNav_OnSelectChanged;
            //this.GdMain.Children.Add(CurNavPage);
        }
    }
}
