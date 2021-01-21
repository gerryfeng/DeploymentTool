using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface ICallLogService
    {
        /// <summary>
        /// 服务访问量统计 按每分/每5分/每小时/每天 
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="type">1:每分钟/2:每5分钟/3:每小时/4:每天</param>
        /// <returns></returns>
        Task<List<LogTimeModel>> TrafficStatisticsAsync(List<CallLog> logs, DateTime start, DateTime end, int type);


    }
}
