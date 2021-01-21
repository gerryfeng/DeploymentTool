using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.ApplicationCore
{
    public class LogConsumeModel
    {
        /// <summary>
        /// 接口路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 平均耗时
        /// </summary>
        public double AvgTime { get; set; }

    }


    public class LogCountModel
    {
        /// <summary>
        /// 接口路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 调用次数
        /// </summary>
        public int Count { get; set; }

    }

    public class LogTimeModel
    {

        /// <summary>
        /// 调用次数
        /// </summary>
        public int Count { get; set; }


        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }

    }

}
