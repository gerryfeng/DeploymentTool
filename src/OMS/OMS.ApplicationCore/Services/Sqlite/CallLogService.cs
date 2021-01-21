using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public class CallLogService : ICallLogService
    {
        /// <summary>
        /// 服务访问量统计 按每分/每5分/每小时/每天 
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="type">1:每分钟/2:每5分钟/3:每小时/4:每天</param>
        /// <returns></returns>
        public async Task<List<LogTimeModel>> TrafficStatisticsAsync(List<CallLog> logs, DateTime start, DateTime end, int type)
        {
            List<LogTimeModel> result = new List<LogTimeModel>();

            double dCount = 0;
            switch (type)
            {
                case 1: dCount = end.Subtract(start).TotalMinutes; break;
                case 2: dCount = end.Subtract(start).TotalMinutes / 5.0; break;
                case 3: dCount = end.Subtract(start).TotalHours ; break;
                case 4: dCount = end.Subtract(start).TotalDays; break;
            }

            int count = (int)Math.Ceiling(dCount);
            DateTime tstart = start;

            for(int i=0; i< count; i++)
            {
                switch (type)
                {
                    case 1://每分
                        {
                            result.Add(new LogTimeModel()
                            {
                                Count = logs.Count(x => Convert.ToDateTime(x.CallTime) >= tstart && Convert.ToDateTime(x.CallTime) <= tstart.AddMinutes(1)),
                                StartTime = tstart.ToString()
                            });
                            tstart = tstart.AddMinutes(1);
                            break;
                        }
                    case 2://每5分钟
                        {
                            result.Add(new LogTimeModel()
                            {
                                Count = logs.Count(x => Convert.ToDateTime(x.CallTime) >= tstart && Convert.ToDateTime(x.CallTime) <= tstart.AddMinutes(5)),
                                StartTime = tstart.ToString()
                            });
                            tstart = tstart.AddMinutes(5);
                            break;

                        }

                    case 3://每小时
                        {
                            result.Add(new LogTimeModel()
                            {
                                Count = logs.Count(x => Convert.ToDateTime(x.CallTime) >= tstart && Convert.ToDateTime(x.CallTime) <= tstart.AddHours(1)),
                                StartTime = tstart.ToString()
                            });
                            tstart = tstart.AddHours(1);
                            break;
                        }
                    case 4://每天
                        {
                            result.Add(new LogTimeModel()
                            {
                                Count = logs.Count(x => Convert.ToDateTime(x.CallTime) >= tstart && Convert.ToDateTime(x.CallTime) <= tstart.AddDays(1)),
                                StartTime = tstart.ToString()
                            });
                            tstart = tstart.AddDays(1);
                            break;
                        }
                    }
                
            }

            return result;
        }

    }
}


