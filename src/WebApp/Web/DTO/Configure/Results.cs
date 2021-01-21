using System.Collections.Generic;

namespace Web.DTO
{
    public class Results<T>
    {
        public Results()
        {
            say = new Status();
            getMe = new List<T>();
            currentPageIndex = 0;
            totalRcdNum = 0;
        }

        public Status say
        {
            get;
            set;
        }

        public List<T> getMe
        {
            get;
            set;
        }

        public int currentPageIndex
        {
            get;
            set;
        }

        public int totalRcdNum
        {
            get;
            set;
        }
    }

    public class Status
    {
        public Status()
        {
            statusCode = "0000";
            errMsg = "";
            info = "";
        }

        /// <summary>
        /// 其他信息
        /// </summary>
        public string info
        {
            get;
            set;
        }
        /// <summary>
        /// 状态码 成功 - 0000
        /// 错误 自定义
        /// </summary>
        public string statusCode
        {
            get;
            set;
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errMsg
        {
            get;
            set;
        }
    }
}
