using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway
{
  
    public class ResponseBase
    {
        /// <summary>
        /// 编码 0-成功
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
    }


    public class Results
    {
        public Status say
        {
            get;
            set;
        }

    }

    public class Status
    {
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
