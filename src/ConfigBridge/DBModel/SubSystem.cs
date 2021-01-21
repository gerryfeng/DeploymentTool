using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConfigBridge
{
    /// <summary>
    /// 子系统 - 用于服务返回
    /// </summary>
    public class SubSystem
    {
        public SubSystem()
        { }

        public SubSystem(string title, string value, string mode, string location)
        {
            this.topTitle = title;
            this.title = title;
            this.value = value;
            this.mode = mode;
            this.location = location;

            if (!string.IsNullOrEmpty(location))
            {
                DirectoryInfo dir = new DirectoryInfo(location);
                this.folder = dir.Name;
            }
            else
            {
                this.folder = "";
            }
        }

        /// <summary>
        /// 子系统标题
        /// </summary>
        public string title;

        /// <summary>
        /// 显示在抽屉栏上的子系统标题
        /// </summary>
        public string topTitle;

        /// <summary>
        /// 子系统值
        /// </summary>
        public string value;

        /// <summary>
        /// 模式，即使用何种系统模板制作出的系统
        /// </summary>
        public string mode;

        /// <summary>
        /// 子系统文件夹名称
        /// </summary>
        public string folder;

        /// <summary>
        /// 子系统文件夹位置
        /// </summary>
        public string location;
    }

    /// <summary>
    /// 子系统 - 用于保存配置文件
    /// </summary>
    public class SubSystemConfigItem
    {
        /// <summary>
        /// 子系统标题
        /// </summary>
        public string title;

        /// <summary>
        /// 子系统值
        /// </summary>
        public string value;

        /// <summary>
        /// 子系统文件夹名称
        /// </summary>
        public string folder;
    }


    public class SaveFileIndexItem
    {
        public int ID;
        public string saveTime;
        public string functionName;
        public string filePath;
        public string fileName;
        public string guid;
    }
}
