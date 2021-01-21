using System;
using Web.DayModule;

namespace Web.Models
{
    /// <summary>
    /// 日期 DTO
    /// </summary>
    public class DayItemDto
    {
        public long Id { get; set; } = -1;
        public DateTime DateInfo { get; set; } = DateTime.Now.Date;
        public bool IsHoliday { get; set; } = false;
        public DayType DateType { get; set; } = DayType.工作日;
        public string Weekday { get; set; }

        public static string GetWeekDay(DateTime dateInfo)
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return weekdays[Convert.ToInt32(dateInfo.DayOfWeek)];
        }
    }
}
