
namespace OMS.ApplicationCore
{
    public class Q_Base
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 一页显示条数
        /// </summary>
        public int PageSize { get; set; } = 20;
    }
}
