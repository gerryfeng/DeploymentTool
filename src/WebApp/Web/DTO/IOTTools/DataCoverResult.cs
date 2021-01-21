using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.IOTTools
{
    public class DataCoverResult
    {

        /// <summary>
        /// 总次数
        /// </summary>
        public int TotalNum { get; set; }

        /// <summary>
        /// 当前执行次数
        /// </summary>
        public int CurrentNum { get; set; } = 0;


        /// <summary>
        /// 当前任务执行时间
        /// </summary>
        public string Time { get; set; }


        /// <summary>
        /// 百分比
        /// </summary>
        public string percentage { get; set; }

    }
}
