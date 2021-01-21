using Microsoft.EntityFrameworkCore;
using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
    public class CallLogRepository : ICallLogRepository
    {

        private readonly SqliteContext _sqliteContext;

        public CallLogRepository(SqliteContext sqliteContext)
        {
            _sqliteContext = sqliteContext;
        }

        public async Task AddCallLogAsync(CallLog entity)
        {
            _sqliteContext.CallLog.Add(entity);
             await _sqliteContext.SaveChangesAsync();
        }


        public PagedList<CallLog> GetPagingList(Q_Log where)
        {
            return new PagedList<CallLog>(Query(where).OrderByDescending(x => x.ConsumerTime), where.PageIndex, where.PageSize);
        }

        public async Task<List<CallLog>> GetListAsync(Q_Log where)
        {
            return await Query(where).ToListAsync();
        }

        /// <summary>
        /// 分页接口，默认按耗时降序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<List<CallLog>> GetCallLogPageListAsync(Q_Log where)
        {
            return await Query(where).OrderByDescending(x => x.ConsumerTime).Skip((where.PageIndex - 1) * where.PageSize).Take(where.PageSize).ToListAsync();
        }


        /// <summary>
        /// 根据平均耗时降序排序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<List<LogConsumeModel>> GetTopConsumeListAsync(Q_Log where)
        {
            var query = Query(where);

            var t = from q in query
                    group q by q.Path into g
                    select new LogConsumeModel
                    {
                        Path = g.Key,
                        AvgTime = g.Average(x => x.ConsumerTime)
                    };
            
            return await t.OrderByDescending(x => x.AvgTime).Skip((where.PageIndex - 1) * where.PageSize).Take(where.PageSize).ToListAsync();
        }

        /// <summary>
        /// 根据调用频次降序排序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<List<LogCountModel>> GetTopCountListAsync(Q_Log where)
        {
            var query = Query(where);

            var t = from q in query
                    group q by q.Path into g
                    select new LogCountModel
                    {
                        Path = g.Key,
                        Count = g.Count()
                    };

            return await t.OrderByDescending(x => x.Count).Skip((where.PageIndex - 1) * where.PageSize).Take(where.PageSize).ToListAsync();
        }


        public IQueryable<CallLog> Query(Q_Log where)
        {
            IQueryable<CallLog> query = _sqliteContext.CallLog.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(where.DateFrom) && !string.IsNullOrWhiteSpace(where.DateTo))
                query = _sqliteContext.CallLog.FromSqlInterpolated($"select * from CallLog where CallTime >= {Convert.ToDateTime(where.DateFrom).ToString("s")} and CallTime <= {Convert.ToDateTime(where.DateTo).ToString("s")} ");
            else if(!string.IsNullOrWhiteSpace(where.DateFrom))
                query = _sqliteContext.CallLog.FromSqlInterpolated($"select * from CallLog where CallTime >= {Convert.ToDateTime(where.DateFrom).ToString("s")}");
            else if (!string.IsNullOrWhiteSpace(where.DateTo))
                query = _sqliteContext.CallLog.FromSqlInterpolated($"select * from CallLog where CallTime <= {Convert.ToDateTime(where.DateTo).ToString("s")}");

        
            if (!string.IsNullOrWhiteSpace(where.IP))
                query = query.Where(x => x.UserIp == where.IP);

            if (!string.IsNullOrWhiteSpace(where.Module))
                query = query.Where(x => x.Path.ToLower().Contains(where.Module.ToLower()));

            if (where.LogType != 9999)
            {
                if (where.LogType == 0)
                    query = query.Where(x => x.Result == 200 && string.IsNullOrEmpty(x.ErrorMsg));
                else
                    query = query.Where(x => x.Result != 200 || !string.IsNullOrEmpty(x.ErrorMsg));
            }

            if (!string.IsNullOrWhiteSpace(where.Description))
                query = query.Where(x => x.ErrorMsg.Contains(where.Description));

            return query;
        }
    }
}
