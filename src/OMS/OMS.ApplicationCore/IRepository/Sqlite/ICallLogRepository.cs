using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface ICallLogRepository
    {

        Task AddCallLogAsync(CallLog entity);


        /// <summary>
        /// 分页获取服务日志
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        PagedList<CallLog> GetPagingList(Q_Log where);


        /// <summary>
        /// 获取平均耗时排前的日志
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<List<LogConsumeModel>> GetTopConsumeListAsync(Q_Log where);


        /// <summary>
        /// 根据调用频次降序排序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<List<LogCountModel>> GetTopCountListAsync(Q_Log where);

        Task<List<CallLog>> GetListAsync(Q_Log where);
    }
}
