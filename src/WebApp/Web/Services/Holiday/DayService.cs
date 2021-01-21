using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DayModule
{
    public partial class DayService : IDayService
    {
        public enum QueryDayType { All = 0, Holiday, WorkDay };
        private HolidayContext _context;
        private readonly IMapper _mapper;


        public DayService(HolidayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
            try
            {
                var databaseCreator = _context.GetService<IRelationalDatabaseCreator>();
                databaseCreator.CreateTables();
            }
            catch (Exception)
            {
                //A SqlException will be thrown if tables already exist. So simply ignore it.
            }
        }

        /// <summary>
        /// 获取数据库节假日表最小日期
        /// </summary>
        /// <returns></returns>
        public DateTime? GetMinInitDate()
        {
            return _context.节假日信息表.Min(d => d.日期);
        }
        
        /// <summary>
        /// 获取数据库节假日表最大日期
        /// </summary>
        /// <returns></returns>
        public DateTime? GetMaxInitDate()
        {
            return _context.节假日信息表.Max(d => d.日期);
        }

        /// <summary>
        /// 设置节假日
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="dayType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool UpdateDays(DateTime beginDate, DayType dayType, int count = 1)
        {
            bool IsHoliday = false;

            if (dayType != DayType.工作日)
                IsHoliday = true;

            var res = _context.节假日信息表.Where(w =>
                (beginDate <= w.日期) && (w.日期 < beginDate.Date.AddDays(count)))
                .ToList();

            // 记录已有的日期记录
            List<DateTime> hadDays = new List<DateTime>();
            foreach (var item in res)
            {
                item.节假日类型 = dayType.ToDescription();
                item.是否节假日 = IsHoliday;
                hadDays.Add(item.日期);
            }

            // 需要新增的记录列表
            List<节假日信息表> newDayItems = new List<节假日信息表>();
            for (int i = 0; i < count; i++)
            {
                DateTime curDate = beginDate.Date.AddDays(i);
                if (!hadDays.Contains(curDate))
                {
                    节假日信息表 day = new 节假日信息表
                    {
                        日期 = beginDate.AddDays(i),
                        是否节假日 = IsHoliday,
                        节假日类型 = dayType.ToDescription(),
                    };
                    newDayItems.Add(day);
                }
            }

            if (newDayItems.Count > 0)
            {
                _context.节假日信息表.AddRange(newDayItems);
            }

            _context.SaveChanges();

            return true;
        }


        /// <summary>
        /// 返回指定时间段内的相关信息
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="count">持续天数</param>
        /// <param name="dayType">All(返回所有), Holiday(节假日), WorkDay(工作日)</param>
        /// <returns></returns>
        public List<DayItemDto> GetHolidayItems(DateTime beginDate, int count = 1, QueryDayType dayType = QueryDayType.All)
        {
            var res = _context.节假日信息表.Where(w =>
                (beginDate <= w.日期) && (w.日期 < beginDate.Date.AddDays(count)))
                .ToList();

            res = dayType switch
            {
                QueryDayType.All => res,
                QueryDayType.Holiday => res.Where(s => s.是否节假日).ToList(),
                QueryDayType.WorkDay => res.Where(s => !s.是否节假日).ToList(),
                _ => res,
            };

            // 记录已有的日期记录
            List<DateTime> hadDays = new List<DateTime>();
            foreach (var item in res)
            {
                hadDays.Add(item.日期);
            }

            // 正常日期自动补全，不依赖数据库
            List<DayItemDto> autoComplete = new List<DayItemDto>();
            for (int i = 0; i < count; i++)
            {
                DateTime curDate = beginDate.Date.AddDays(i);
                if (!hadDays.Contains(curDate))
                {
                    bool IsWeek = (curDate.Date.DayOfWeek == DayOfWeek.Saturday)
                            || (curDate.Date.DayOfWeek == DayOfWeek.Sunday);
                    DayItemDto item = new DayItemDto
                    {
                        IsHoliday = IsWeek,
                        DateInfo = curDate,
                        DateType = IsWeek ? DayType.周末 : DayType.工作日,
                        Weekday = DayItemDto.GetWeekDay(curDate)
                    };

                    item = dayType switch
                    {
                        QueryDayType.All => item,
                        QueryDayType.Holiday => IsWeek ? item : null,
                        QueryDayType.WorkDay => IsWeek ? null : item,
                        _ => null
                    };

                    if (item != null)
                    {
                        autoComplete.Add(item);
                    }
                }
            }

            var ret = _mapper.Map<List<节假日信息表>, List<DayItemDto>>(res).Concat(autoComplete).ToList();
            ret.Sort((b, e) => (b.DateInfo.Date - e.DateInfo.Date).Days);
            return ret;
        }
    }
}
