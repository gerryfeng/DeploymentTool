using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PublishTool.Tool;
using PublishTool.Tool.Model;

namespace PublishTool.Views
{
    /// <summary>
    /// WebAdd.xaml 的交互逻辑
    /// </summary>
    public partial class WebAdd : Page
    {
        List<Task> tasks = new List<Task>();
        public WebAdd()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        private void btn_AddClick(object sender, RoutedEventArgs e)
        {
            var configPath = AppDomain.CurrentDomain.BaseDirectory + "config.json";
            JsonConfigHelper helper = new JsonConfigHelper(configPath);
            lodingGrid.Visibility = Visibility.Visible;
            b1.IsEnabled = false;
            var gitPackages = helper.GetValue<List<GitPackage>>("GitPackages");
            var filePath = this.Filepath.Text;
            var directoryStr = filePath + gitPackages.Find(x => x.PackageName.Equals("Publish")).StoragePath;
            if (string.IsNullOrEmpty(directoryStr))
            {
                System.Windows.Forms.MessageBox.Show("部署服务前请选择文件路径");
            }
            else
            {
                MainClon(directoryStr, gitPackages);
            }
           
        }
        private async void MainClon(string directoryStr,List<GitPackage> gitPackages) 
        {
            TaskCallBack += Accomplish;
            WriteHelp.IsExistDirectory(directoryStr);
            foreach (var item in gitPackages)
            {
                if (item.PackageName== "Publish")
                {
                    var path = this.Filepath.Text + item.StoragePath;
                    tasks.Add(Task.Run(() => clone(path, " clone " + item.DownloadURL, item.PackageName)));
                }
               
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
            Home home = new Home();
            NavigationService.GetNavigationService(this).Navigate(home);

        }
        private void clone(string initPath, string cloneUrl, string package)
        {
            try
            {

                var git = new CommandRunner("git", initPath);

                string logs = git.Run(cloneUrl);

                //if (string.IsNullOrEmpty(logs)) 
                //{
                //    if (package== "Publish")
                //    {


                //    }
                //}
                //Thread.Sleep(6000);
                //UpdataUIStatus(1);
                //MessageBox.Show("开始任务");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("获取" + package + "包异常" + ex.StackTrace);
            }

        }
        private void btn_FileClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  //选择文件夹


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//注意，此处一定要手动引入System.Window.Forms空间，否则你如果使用默认的DialogResult会发现没有OK属性
            {
                Filepath.Text = openFileDialog.SelectedPath;
            }
        }

    }
}
