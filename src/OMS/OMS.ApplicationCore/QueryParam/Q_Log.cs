
namespace OMS.ApplicationCore
{
    public class Q_Log : Q_Base
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        public string DateFrom { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string DateTo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string HourFrom { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string HourTo { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// 日志类型  0:成功 -1:错误 9999:全部
        /// </summary>
        public int LogType { get; set; } = 9999;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 统计类型
        /// 1:每分钟/2:每5分钟/3:每小时/4:每天
        /// </summary>
        public int StaticsType { get; set; }
    }
}
