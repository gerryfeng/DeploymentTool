using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMS.ApplicationCore;

namespace OMS.Web
{   
    /// <summary>
    /// 日志中心
    /// </summary>
    public class LogCenterController : BaseApiController
    {
        private readonly ILogger<LogCenterController> _logger;
        private readonly ISysUserLoginRepository _userLoginRepository;
        private readonly ICallLogService _callLogService;
        private readonly ICallLogRepository _callLogRepository;

        public LogCenterController(ILogger<LogCenterController> logger, ISysUserLoginRepository userLoginRepository, ICallLogRepository callLogRepository, ICallLogService callLogService)
        {
            _logger = logger;
            _userLoginRepository = userLoginRepository;
            _callLogRepository = callLogRepository;
            _callLogService = callLogService;
        }

        #region 服务频次调用日志

        /// <summary>
        /// 获取服务调用日志明细
        /// </summary>
        /// <param name="logQuery">日志查询参数</param>
        /// <returns></returns>
        [HttpPost]
        public PagedList<CallLog> GetOMSLog([Required] Q_Log logQuery)
        {          
              return _callLogRepository.GetPagingList(logQuery);           
        }


        /// <summary>
        /// 平均耗时排名统计
        /// </summary>
        /// <param name="logQuery">日志查询参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LogConsumeModel>> TopConsumeListAsync([Required] Q_Log logQuery)
        {
              return await _callLogRepository.GetTopConsumeListAsync(logQuery);  
        }

        /// <summary>
        /// 调用频次排名统计
        /// </summary>
        /// <param name="logQuery">日志查询参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LogCountModel>> TopCountListAsync([Required] Q_Log logQuery)
        {
               return await _callLogRepository.GetTopCountListAsync(logQuery);
        }

        /// <summary>
        /// 服务访问量统计 按每分/每5分/每小时/每天 
        /// </summary>
        /// <param name="logQuery">日志查询参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LogTimeModel>> TrafficStatisticsAsync([Required] Q_Log logQuery)
        {
            List<LogTimeModel> logTimeModels = null;
            if (string.IsNullOrEmpty(logQuery.DateFrom))
                logQuery.DateFrom = DateTime.Now.AddDays(-1).ToString();
            if(string.IsNullOrEmpty(logQuery.DateTo))
                logQuery.DateTo = DateTime.Now.ToString();

            DateTime start, end;
            if(!DateTime.TryParse(logQuery.DateFrom, out start) || !DateTime.TryParse(logQuery.DateTo, out end))
            {
                throw new Exception ("时间格式错误！");
            }

            if (logQuery.StaticsType == 0) logQuery.StaticsType = 2;
         
            List<CallLog> list = await _callLogRepository.GetListAsync(logQuery);

            if (list.Count > 0)
            {
                logTimeModels= await _callLogService.TrafficStatisticsAsync(list, start, end, logQuery.StaticsType);
            }
            return logTimeModels;
        }
        #endregion

        /// <summary>
        /// 获取运维登录日志
        /// </summary>
        /// <param name="logQuery">日志查询参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<SysUserLogin>> GetLoginLog([Required] Q_Log logQuery)
        {
            return await _userLoginRepository.GetListAsync(logQuery);
        }
    }
}