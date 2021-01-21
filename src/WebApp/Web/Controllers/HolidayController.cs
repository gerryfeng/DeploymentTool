using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DayModule;
using Web.Models;
using static Web.DayModule.DayService;

namespace Web.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HolidayController : ControllerBase
    {
        private readonly ILogger<HolidayController> _logger;
        private readonly IDayService _holiday;

        public HolidayController(ILogger<HolidayController> logger, IDayService holiday)
        {
            _logger = logger;
            _holiday = holiday;
        }

        /// <summary>
        /// 获取最小日期
        /// </summary>
        /// <returns>日期详情</returns>
        [HttpGet("Day/MinDate")]
        public IActionResult GetMinInitDate()
        {
            var res = _holiday.GetMinInitDate();
            return Ok(res);
        }

        /// <summary>
        /// 获取最大日期
        /// </summary>
        /// <returns>日期详情</returns>
        [HttpGet("Day/MaxDate")]
        public IActionResult GetMaxInitDate()
        {
            var res = _holiday.GetMaxInitDate();
            return Ok(res);
        }


        /// <summary>
        /// 修改指定日期区间的节假日类型
        /// </summary>
        /// <param name="beginDate">开始日期</param>
        /// <param name="count">持续天数</param>
        /// <param name="dayType">节假日类型：0工作日 1周末 2元旦 3春节 4清明节 5端午节 6中秋节 7国庆节 8调休</param>
        /// <returns></returns>
        [HttpPost("Days")]
        public IActionResult UpdateDays(DateTime beginDate, int count, DayType dayType)
        {
            if (beginDate.Year < 2 || count < 1)
            {
                return NoContent();
            }

            _holiday.UpdateDays(beginDate, dayType, count);
            return Ok();
        }

        /// <summary>
        /// 获取指定日期详情
        /// </summary>
        /// <remarks>
        /// 示例请求：
        /// 
        ///     Get /Days
        ///     {
        ///         "beginDate": "2020-2-4",
        ///         "count": 7
        ///     }
        ///     
        /// </remarks>
        /// <param name="beginDate">开始日期</param>
        /// <param name="count">持续天数</param>
        /// <param name="queryDayType">All(返回所有), Holiday(节假日), WorkDay(工作日)</param>
        /// <returns>日期详情</returns>
        [HttpGet("Days")]
        public ActionResult<List<DayItemDto>> GetDays(DateTime beginDate, int count, QueryDayType queryDayType = QueryDayType.All)
        {
            if (beginDate == null || count < 1)
            {
                return NoContent();
            }

            var res = _holiday.GetHolidayItems(beginDate, count, queryDayType);
            return Ok(res);
        }


        // Message InitHolidayTableData([SwaggerWcfParameter(true, "开始年限(例:2000)")]int beginYear, [SwaggerWcfParameter(true, "结束年限")]int endYear);
        // Message GetMinInitDate();
        // Message GetMaxInitDate();
        // Message SetHoliday([SwaggerWcfParameter(true, "开始日期(例:2000-12-25T00:00:00)")]DateTime beginDate, [SwaggerWcfParameter(true, "结束日期")]DateTime endDate, [SwaggerWcfParameter(true, "假期类型")]HolidayType holidayType);
        // Message SetWorkDay([SwaggerWcfParameter(true, "待设置的日期0工作日1周末2元旦节3春节4清明节5端午节6中秋节7国庆节8调休")]DateTime dateInfo);
        // Message IsHoliday([SwaggerWcfParameter(true, "需要判断的时间(例:2000-12-25T00:00:00)")]DateTime dateInfo);
        // Message GetHolidayItems([SwaggerWcfParameter(true, "开始时间(例:2000-12-25T00:00:00)")]DateTime beginTime, [SwaggerWcfParameter(true, "结束时间(例:2000-12-25T00:00:00)")] DateTime endTime, [SwaggerWcfParameter(true, "All(返回所有), Holiday(节假日), WorkDay(工作日)")]QueryDayType dayType);

    }
}
