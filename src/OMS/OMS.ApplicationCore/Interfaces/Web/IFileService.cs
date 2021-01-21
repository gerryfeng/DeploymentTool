using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OMS.ApplicationCore
{
    public interface IFileService
    {
        /// <summary>
        /// 获取子级文件
        /// </summary>
        /// <param name="di">文件夹</param>
        /// <param name="m"></param>
        /// <param name="flieSpilt"></param>
        /// <param name="child"></param>
        void FindFile(DirectoryInfo di, FileModel m, string flieSpilt, FileModel child = null);
    }
}
