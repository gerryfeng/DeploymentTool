using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PublishTool.Tool
{
    public class WriteHelp
    {
        public static bool WriteFile(string str, string sFileName)
        {
            DateTime now = DateTime.Now;
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            string sMethodName = st.GetFrame(1).GetMethod().Name;
            string pathRoot = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).FullName).FullName + "\\";
            string pathRootLog = pathRoot + @"Log\";
            str = string.Join(":", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"), str);
            string path = "";
            string sPath = "";
            try
            {
                sPath = pathRootLog + @"\";
                if (!IsExistDirectory(sPath))
                {
                    return false;
                }
                path = sPath + @"\" + sFileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (File.Exists(path))
                {
                    FileInfo info = new FileInfo(path);
                    if (info.Length > 0xa00000L)
                    {
                        info.Delete();
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(path, true);
                        writer.WriteLine(str);
                        writer.Flush();
                        writer.Close();
                    }
                }
                else
                {
                    DateTime time2 = now.AddDays(-30.0);
                    foreach (string str4 in Directory.GetFiles(sPath, "*.txt", SearchOption.AllDirectories))
                    {
                        FileInfo info2 = new FileInfo(str4);
                        if (info2.CreationTime <= time2)
                        {
                            info2.Delete();
                        }
                    }
                    StreamWriter writer2 = File.CreateText(path);
                    writer2.WriteLine(str);
                    writer2.Flush();
                    writer2.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool IsExistDirectory(string sPath)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(sPath);
                if (!info.Exists)
                {
                    info.Create();
                    AddPathPower(sPath, "Everyone", "FullControl");
                }
            }
            catch (Exception exception)
            {
                string message = exception.Message;
                return false;
            }
            return true;
        }

        public static void AddPathPower(string pathName, string userName, string power)
        {

            DirectoryInfo dirinfo = new DirectoryInfo(pathName);

            if ((dirinfo.Attributes & FileAttributes.ReadOnly) != 0)
            {
                dirinfo.Attributes = FileAttributes.Normal;
            }

            //取得访问控制列表   
            DirectorySecurity dirsecurity = dirinfo.GetAccessControl();

            switch (power)
            {
                case "FullControl":
                    InheritanceFlags inherits = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
                    //dirsecurity.AddAccessRule(new FileSystemAccessRule(userName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(userName, FileSystemRights.FullControl, inherits, PropagationFlags.None, AccessControlType.Allow));
                    break;
                case "ReadOnly":
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(userName, FileSystemRights.Read, AccessControlType.Allow));
                    break;
                case "Write":
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(userName, FileSystemRights.Write, AccessControlType.Allow));
                    break;
                case "Modify":
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(userName, FileSystemRights.Modify, AccessControlType.Allow));
                    break;
            }
            dirinfo.SetAccessControl(dirsecurity);
        }
    }
}
