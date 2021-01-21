using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using static Web.DayModule.DayService;

namespace Web.DayModule
{
    public interface IDayService
    {
        public DateTime? GetMinInitDate();

        public DateTime? GetMaxInitDate();

        public List<DayItemDto> GetHolidayItems(DateTime beginTime, int count = 1, 
            QueryDayType dayType = QueryDayType.All);

        public bool UpdateDays(DateTime beginDate, DayType holidayType, int count = 1);
    }
}
