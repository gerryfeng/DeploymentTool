using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OMS.ApplicationCore
{
    public class FileService : IFileService
    {
        /// <summary>
        /// 获取子级文件
        /// </summary>
        /// <param name="di">文件夹</param>
        /// <param name="m"></param>
        /// <param name="flieSpilt"></param>
        /// <param name="child"></param>
        public void FindFile(DirectoryInfo di, FileModel m, string flieSpilt, FileModel child = null)
        {
            //找到该目录下的文件 

            FileInfo[] fis = di.GetFiles();
            foreach (FileInfo fi in fis)
            {
                if (child == null)
                    m.fileUrls.Add(fi.FullName.Substring(fi.FullName.IndexOf(flieSpilt)));
                else
                    child.fileUrls.Add(fi.FullName.Substring(fi.FullName.IndexOf(flieSpilt)));
            }

            DirectoryInfo[] dis = di.GetDirectories();
            foreach (DirectoryInfo d in dis)
            {
                if (flieSpilt == "CityTemp" && d.Name == "Preview") continue;

                FileModel t = new FileModel() { moduleName = d.FullName.Substring(d.FullName.IndexOf(flieSpilt)) };

                FindFile(d, m, flieSpilt, t);

                if (t.fileUrls.Count > 0)
                    m.child.Add(t);
            }
        }
    }
}
