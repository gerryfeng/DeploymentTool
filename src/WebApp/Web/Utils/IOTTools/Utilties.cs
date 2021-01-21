using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Utils.IOTTools
{
    public class Utilties
    {


        /// <summary>
        /// 生成临时表存放时间周期的历史数据
        /// </summary>
        /// <param name="cycleBegin">开始时间(最新时间)</param>
        /// <param name="cycleEnd">结束时间</param>
        /// <returns></returns>
        public static string GenerateStatisticCycleCommand(DateTime cycleBegin, DateTime cycleEnd)
        {
            string commandText;
            string begin = cycleBegin.ToString("yyyy-MM-dd HH:mm:ss"); 
            string end = cycleEnd.ToString("yyyy-MM-dd HH:mm:ss");

            // 为防止 real -> float 转换时产生小数点, [值] 统一转为 varchar(50) 类型来过渡 (如果直接转为 float 则会出现小数)
            commandText = "create table #HistoryStatisticResult(SensorID int, PV varchar(50), PT datetime );\n" +
                "insert into #HistoryStatisticResult (SensorID, PV, PT)\n";

            commandText += $"select SensorID, PV, PT\n" +
                           $"from SCADA_SensorHistory where PT > '{end}' and PT <= '{begin}' ";
            return commandText;
        }

    }
}
