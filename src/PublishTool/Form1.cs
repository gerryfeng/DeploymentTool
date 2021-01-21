using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Microsoft.Web.Administration;
using System.IO;
using Application = Microsoft.Web.Administration.Application;
using Binding = Microsoft.Web.Administration.Binding;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WindowsFormsApp1;

namespace PublishTool
{
    public partial class Form1 : Form
    {
        private static ServerManager manager;
        private string directoryStr = string.Empty, filePath = string.Empty;
        private List<GitPackage> gitPackages;
        private string[] apps;
        private List<CheckBox> checkBoxes;
        List<Task> tasks = new List<Task>();

        public Form1()
        {
            InitializeComponent();
        }

        #region form窗体事件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确认要退出吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Dispose();
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //读取配置文件git包路径
            GetConfigJson();
            //填充菜单树
            FillTreeView();
            //填充复选框
            FillCheckbox();
            //设置复选框状态
            SetCheckbox(null);
        }
        #endregion

        /// <summary>
        /// 获取当前IIS站点列表
        /// </summary>
        /// <returns></returns>

        public void FillTreeView()
        {
            try
            {
                treeView1.Nodes.Clear();
                manager = new ServerManager();
                TreeNode root = new TreeNode();
                root.Text = "网站";
                treeView1.Nodes.Add(root);//根节点
                SiteCollection siteCollection = manager.Sites;
                foreach (Site model in siteCollection)
                {
                    string str = GetPhysicalPathBySite(model);
                    string fileName = str.Substring(str.LastIndexOf("\\") + 1);

                    if (model.Name.Equals("Default Web Site") || !fileName.Equals(gitPackages[0].PackageName))
                    {
                        continue;
                    }

                    TreeNode tn = new TreeNode();
                    tn.Text = model.Name;
                    tn.Tag = model.Name;
                    this.treeView1.Nodes[0].Nodes.Add(tn);

                    DirectoryInfo theFolder = new DirectoryInfo(GetPhysicalPathBySite(model));
                    DirectoryInfo[] dirInfo = theFolder.GetDirectories();
                    foreach (DirectoryInfo item in dirInfo)
                    {
                        TreeNode tc = new TreeNode();
                        tc.Text = item.Name;
                        tc.Tag = model.Name;
                        tn.Nodes.Add(tc);
                        if (item.Name.Equals("Publish"))
                        {
                            foreach (DirectoryInfo app in item.GetDirectories())
                            {
                                TreeNode td = new TreeNode();
                                td.Text = app.Name;
                                td.Tag = model.Name;
                                tc.Nodes.Add(td);
                            }
                        }

                    }
                    root.Expand();

                }
            }
            catch (Exception ex)
            {
                setText(ex.Message, txt_log);
            }
        }

        private string GetPhysicalPathBySite(Site site)
        {
            var applicationRoot = site.Applications.Where(a => a.Path == "/").Single();
            var virtualRoot = applicationRoot.VirtualDirectories.Where(v => v.Path == "/").Single();
            string directory = virtualRoot.PhysicalPath;
            return directory;
        }

        private void FillCheckbox()
        {
            checkBoxes = new List<CheckBox>();
            for (int i = 0; i < gitPackages.Count; i++)
            {
                CheckBox box = new CheckBox();
                box.Text = gitPackages[i].DisplayName;
                box.Name = gitPackages[i].PackageName;
                box.Location = new Point(10, 30 + i * 30);
                box.AutoSize = true;
                this.groupBox4.Controls.Add(box);
                checkBoxes.Add(box);
            }
        }

        private void GetConfigJson()
        {
            string configPath = Directory.GetCurrentDirectory() + "\\config.json";
            JsonConfigHelper helper = new JsonConfigHelper(configPath);
            gitPackages = helper.GetValue<List<GitPackage>>("GitPackages");
            apps = helper.GetValue<string[]>("CoreApp");

        }

        /// <summary>
        /// 设置复选框勾选状态
        /// </summary>
        /// <param name="site"></param>
        public void SetCheckbox(Site site)
        {
            if (site == null)
            {
                for (int i = 0; i < checkBoxes.Count; i++)
                {
                    var box = checkBoxes[i];
                    box.Checked = true;
                    box.Enabled = true;
                    box.ForeColor = Color.Black;
                }
                return;
            }
            if (site.Name.Equals("Default Web Site"))
            {
                return;
            }
            DirectoryInfo theFolder = new DirectoryInfo(GetPhysicalPathBySite(site));
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            checkBoxes[0].Enabled = false;
            checkBoxes[0].ForeColor = System.Drawing.Color.Gray;
            DirectoryInfo publish = Array.Find(dirInfo, s => s.Name.Equals("Publish"));
            if (publish != null)
            {
                var p = checkBoxes.Find(x => x.Name.Equals("Publish"));
                p.Enabled = false;
                p.ForeColor = System.Drawing.Color.Gray;
            }
            DirectoryInfo confCenter = Array.Find(dirInfo, s => s.Name.Equals("ConfCenter"));
            if (confCenter != null)
            {
                var c = checkBoxes.Find(x => x.Name.Equals("ConfCenter"));
                c.Enabled = false;
                c.ForeColor = System.Drawing.Color.Gray;
            }

        }

        /// <summary>
        /// 文件选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_chooseFile(object sender, EventArgs e)
        {
            #region 打开文件夹
            folderBrowserDialog1.SelectedPath = filePath;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.folderBrowserDialog1.SelectedPath.Trim() != "")
                    filePath = this.folderBrowserDialog1.SelectedPath.Trim();
                
            }
            #endregion

            #region 打开文件
            /*
            OpenFileDialog openFileDialog1 = new OpenFileDialog();     //显示选择文件对话框
            openFileDialog1.FileName = filePath;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;          //显示文件路径
            }
            */
            #endregion

            this.txt_path.Text = filePath;
            directoryStr = filePath + gitPackages.Find(x => x.PackageName.Equals("Publish")).StoragePath;
        }

        /// <summary>
        /// 拉取代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pull_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(directoryStr))
                {
                    setText("部署服务前请选择文件路径", txt_log);
                    return;
                }
                WriteHelp.IsExistDirectory(directoryStr);
                TaskCallBack += Accomplish;
                UpdateUIDelegate += UpdataUIStatus;
                this.pgbWrite.Maximum = checkBoxes.Where(x => x.Enabled && x.Checked).Count();
                this.pgbWrite.Value = 0;
                lblWriteStatus.Text = "0/" + checkBoxes.Where(x => x.Enabled && x.Checked).Count().ToString();
                //LoadingHelper.ShowLoadingScreen();

                //禁用按钮及控件
                btn_pull.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = false;
                treeView1.Enabled = false;

                Test();

                //clone(this.txt_path.Text, " clone https://gitlab+deploy-token-54:Epe9b4MtKSCUWhspDYby@g.civnet.cn:8443/CivPublish/CivWebPublish2021.git", "正在下载CivWebPublish2021包...", this.txt_log);
                //clone(this.txt_path.Text + "\\CivWebPublish2021", " clone https://gitlab+deploy-token-10:tPPy6xZxTU2SYqznimfx@g.civnet.cn:8443/CivDevelope/ConfCenter.git", "正在下载ConfCenter包...", this.txt_log);
                //clone(this.txt_path.Text + "\\CivWebPublish2021", " clone https://gitlab+deploy-token-54:Epe9b4MtKSCUWhspDYby@g.civnet.cn:8443/CivPublish/Publish.git", "正在下载Publish包...", this.txt_log);
            }
            catch (Exception ex)
            {

            }
        }

        private void DoPull()
        {
            List<Task> tasks = new List<Task>();
            foreach (CheckBox model in checkBoxes)
            {
                if (model.Enabled && model.Checked)
                {
                    GitPackage item = gitPackages.Find(x => x.PackageName.Equals(model.Text));
                    tasks.Add(Task.Factory.StartNew(() => clone(this.txt_path.Text + item.StoragePath, " clone " + item.DownloadURL, item.PackageName, this.txt_log)));
                }
            }
            Task.WaitAll(tasks.ToArray());

            TaskCallBack();
        }

        private async void Test()
        {
            string path;
            foreach (CheckBox model in checkBoxes)
            {
                if (model.Enabled && model.Checked)
                {
                    GitPackage item = gitPackages.Find(x => x.PackageName.Equals(model.Name));
                    if (init.TabPages[0].Text.Equals("服务部署"))
                    {
                        path = filePath + item.StoragePath;
                    }
                    else
                    {
                        path = filePath;
                    }
                    tasks.Add(Task.Run(() => clone(path, " clone " + item.DownloadURL, item.PackageName, this.txt_log)));
                    setText("文件路径:" + path + "---远端地址:" + " clone " + item.DownloadURL + "---包名:" + item.PackageName, txt_log);
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
            LoadingHelper.CloseForm();
            tasks.Clear();

            btn_pull.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = true;
            treeView1.Enabled = true;
        }

        AsynUpdateUI UpdateUIDelegate;
        delegate void AsynUpdateUI(int step);
        private void UpdataUIStatus(int step)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate (int s)
                {

                    this.pgbWrite.Value += s;
                    this.lblWriteStatus.Text = this.pgbWrite.Value.ToString() + "/" + checkBoxes.Where(x => x.Enabled && x.Checked).Count();
                }), step);
            }
            else
            {
                this.pgbWrite.Value += step;
                this.lblWriteStatus.Text = this.pgbWrite.Value.ToString() + "/" + checkBoxes.Where(x => x.Enabled && x.Checked).Count();
            }
        }

        private void clone(string initPath, string cloneUrl, string package, RichTextBox logBox)
        {
            try
            {
                setText($"正在执行命令---git" + cloneUrl, logBox);
                var git = new CommandRunner("git", initPath);

                string logs = git.Run(cloneUrl);

                if (string.IsNullOrEmpty(logs))
                    setText($"{package}包已成功获取", logBox);

                //Thread.Sleep(6000);
                UpdataUIStatus(1);
                //MessageBox.Show("开始任务");
            }
            catch (Exception ex)
            {
                setText("获取" + package + "包异常" + ex.StackTrace, logBox);
            }

        }

        private void pull(string initPath, RichTextBox logBox)
        {
            try
            {
                setText($"正在执行命令---git pull", logBox);
                var git = new CommandRunner("git", initPath);

                string logs = git.Run("pull");

                setText($"pull命令已完成", logBox);

            }
            catch (Exception ex)
            {
                setText("pull命令执行异常：" + ex.StackTrace, logBox);
            }

        }

        #region 控件跨线程访问
        private delegate void setRichTexBox(string s, RichTextBox logBox);
        public void setText(string txt, RichTextBox logBox)
        {
            if (logBox.InvokeRequired)//等待异步
            {
                setRichTexBox fc = new setRichTexBox(Set);
                this.Invoke(fc, new object[] { txt, logBox });
            }
            else
            {
                Set(txt, logBox);
            }
        }
        private void Set(string txt, RichTextBox logBox)
        {
            WriteHelp.WriteFile(txt, "Operation");
            logBox.AppendText(txt);
            logBox.AppendText("\n");
            logBox.Focus();
            logBox.Select(logBox.TextLength, 0);
        }
        #endregion

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

        #region 创建网站、应用程序池封装方法

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
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            string siteName = text_site.Text;
            string ip = text_ip.Text;
            string port = text_port.Text;

            if (string.IsNullOrWhiteSpace(siteName) || string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(port))
            {
                setText("网站名称、ip、端口号为必填参数", txt_log);
                return;
            }
            if (string.IsNullOrWhiteSpace(directoryStr))
            {
                setText("创建网站前请选择文件路径", txt_log);
                return;
            }
            button4.Enabled = false;
            try
            {
                #region 校验网站名称，IP，端口号不能重复

                //判断该网站是新建还是修改
                if (init.TabPages[0].Text.Equals("服务部署"))
                {
                    if (IsWebsiteExists(siteName))
                    {
                        setText("该网站名称已存在", txt_log);
                        text_site.Text = "";
                        return;
                    }

                    foreach (var s in manager.Sites)//遍历网站
                    {
                        if (!s.Name.Equals("Default Web Site"))
                        {
                            foreach (var tmp in s.Bindings)
                            {
                                if (tmp.EndPoint.Address.ToString().Equals(ip.Equals("*") ? "0.0.0.0" : ip) && tmp.EndPoint.Port.ToString().Equals(port))
                                {
                                    setText("已部署的网站中存在相同的IP、端口号", txt_log);
                                    text_port.Text = "";
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var s in manager.Sites)//遍历网站
                    {
                        if (!s.Name.Equals("Default Web Site") && !s.Name.Equals(siteName))
                        {
                            foreach (var tmp in s.Bindings)
                            {
                                if (tmp.EndPoint.Address.ToString().Equals(ip.Equals("*") ? "0.0.0.0" : ip) && tmp.EndPoint.Port.ToString().Equals(port))
                                {
                                    setText("已部署的网站中存在相同的IP、端口号", txt_log);
                                    text_port.Text = "";
                                    return;
                                }
                            }
                        }
                    }
                }

                #endregion

                setConfiguration(ip, port);

                CreateSite(siteName, ip, Convert.ToInt32(port), directoryStr);

                if (init.TabPages[0].Text.Equals("服务部署"))
                {
                    setText("IIS网站创建完成", txt_log);
                }
                else
                {
                    TreeNode tn = treeView1.SelectedNode;
                    Site site = FindSiteBySiteName(tn.Tag.ToString());
                    List<ApplicationPool> poolCollection = manager.ApplicationPools.Where(s => s.Name.StartsWith(site.Name + "_")).ToList();
                    foreach (ApplicationPool pool in poolCollection)
                    {
                        pool.Recycle();
                    }
                    setText("IIS.NETCore服务重启完成", txt_log);
                }
            }catch(Exception ex)
            {
                string exStr = ex.StackTrace;
                setText("程序执行异常:" + exStr.Substring(exStr.LastIndexOf("\\") + 1, exStr.Length - exStr.LastIndexOf("\\") - 1) + "----" + ex.Message,txt_log);
            }

            text_site.Enabled = true;
            text_site.Text = "";
            text_ip.Text = "*";
            text_port.Text = "";
            directoryStr = "";
            button4.Enabled = true;
            ip = ip.Equals("*") ? "localhost" : ip;
            FillTreeView();
            setText("给第三方使用需要替换ip为服务器配置ip", txt_log);
            setText($"Web应用：http://{ip}:{port}/web4/?client=city", txt_log);
            setText($"新运维平台：http://{ip}:{port}/CivManage/user/login", txt_log);
            setText($"旧运维平台：http://{ip}:{port}/cityoms3/4.0.html", txt_log);
        }

        /// <summary>
        /// 修改网站配置文件
        /// </summary>
        private void setConfiguration(string ip, string port)
        {
            ip = ip.Equals("*") ? "localhost" : ip;
            string omsPath = directoryStr + "\\ConfCenter\\NetCoreConfigs\\OMS\\appsettings.json";
            string identityPath = directoryStr + "\\ConfCenter\\NetCoreConfigs\\Identity\\identity.json";
            string ocelotPath = directoryStr + "\\ConfCenter\\NetCoreConfigs\\GateWay\\ocelot.json";
            bool IsGateWAY = this.radioButton4.Checked;
            try
            {
                setText("正在修改服务配置文件...", txt_log);
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
                setText("修改服务配置文件完成", txt_log);

            }
            catch (Exception ex)
            {
                setText("修改服务配置文件失败：" + ex.StackTrace, txt_log);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FillTreeView();
        }

        private void toolStripMenuUpdate_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            Site site = FindSiteBySiteName(tn.Tag.ToString());
            text_site.Text = site.Name;

            text_ip.Text = site.Bindings[0].EndPoint.Address.ToString();
            text_port.Text = site.Bindings[0].EndPoint.Port.ToString();

            text_site.Enabled = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            if (tn.Tag == null)
            {
                SetCheckbox(null);
                txt_path.Text = "";
                button3.Enabled = true;
                init.TabPages[0].Text = "服务部署";
                text_site.Enabled = true;
                text_site.Text = "";
                text_ip.Text = "*";
                text_port.Text = "";
                directoryStr = "";
                filePath = "";
                SetCheckbox(null);
                return;
            }
            SetCheckbox(null);
            Site site = FindSiteBySiteName(tn.Tag.ToString());
            SetCheckbox(site);

            directoryStr = GetPhysicalPathBySite(site);
            txt_path.Text = directoryStr.Remove(directoryStr.LastIndexOf("\\"));
            filePath = directoryStr;

            button3.Enabled = false;

            init.TabPages[0].Text = site.Name;

            text_site.Text = site.Name;
            text_ip.Text = site.Bindings[0].EndPoint.Address.ToString().Equals("0.0.0.0") ? "*" : site.Bindings[0].EndPoint.Address.ToString();
            text_port.Text = site.Bindings[0].EndPoint.Port.ToString();
            text_site.Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Tag == null)
            {
                setText("请先选择需要更新的站点", txt_log);
                return;
            }
            TreeNode tn = treeView1.SelectedNode;
            Site site = FindSiteBySiteName(tn.Tag.ToString());
            List<ApplicationPool> poolCollection = manager.ApplicationPools.Where(s => s.Name.StartsWith(site.Name + "_")).ToList();
            string add = GetPhysicalPathBySite(site);
            if (tn.Parent.Text.Equals("Publish"))
            {
                add = add + "\\Publish";
                foreach (ApplicationPool pool in poolCollection)
                {
                    pool.Stop();
                }
                Task.Run(() =>pull(add, this.txt_log));
                setText("文件路径:" + add + "---远端命令: pull ", txt_log);
                foreach (ApplicationPool pool in poolCollection)
                {
                    pool.Start();
                }
            }
            else
            {
                Task.Run(() => pull(add, this.txt_log));
                setText("文件路径:" + add + "---远端命令: pull ", txt_log);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Tag == null)
            {
                setText("请先选择需要浏览的站点", txt_log);
                return;
            }
            TreeNode tn = treeView1.SelectedNode;
            Site site = FindSiteBySiteName(tn.Tag.ToString());
            directoryStr = GetPhysicalPathBySite(site);
            System.Diagnostics.Process.Start("explorer.exe", directoryStr);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Tag == null)
            {
                setText("请先选择需要删除的站点", txt_log);
                return;
            }
            TreeNode tn = treeView1.SelectedNode;
            string siteName = tn.Tag.ToString();
            Site site = FindSiteBySiteName(siteName);

            //1.删除站点对应的应用程序
            List<Application> applicationCollection = site.Applications.ToList();
            foreach (Application application in applicationCollection)
            {
                site.Applications.Remove(application);
            }
            //2.删除站点
            manager.Sites.Remove(manager.Sites[site.Name]);
            //3.删除站点归属的应用程序池
            List<ApplicationPool> poolCollection = manager.ApplicationPools.Where(s => s.Name.Contains(site.Name)).ToList();
            foreach (ApplicationPool pool in poolCollection)
            {
                manager.ApplicationPools.Remove(pool);
            }
            //4.重新加载站点树
            manager.CommitChanges();
            FillTreeView();
            setText($"{siteName}站点删除成功", txt_log);
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void toolStripMenuAdd_Click(object sender, EventArgs e)
        {
            SetCheckbox(null);
            txt_path.Text ="";
            button3.Enabled = true;
            init.TabPages[0].Text = "服务部署";
            text_site.Enabled = true;
            text_site.Text = "";
            text_ip.Text = "";
            text_port.Text = "";
            directoryStr = "";
            SetCheckbox(null);
        }
       
    }
}
