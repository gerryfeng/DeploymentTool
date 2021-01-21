
namespace OMS.ApplicationCore
{
   
    /// <summary>
    /// 子系统 - 用于服务返回
    /// </summary>
    public class SubSystemModel
    {

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
}
