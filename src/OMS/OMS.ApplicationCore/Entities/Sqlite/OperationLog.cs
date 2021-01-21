using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;

namespace OMS.ApplicationCore
{
    public class OperationLog: BaseEntity
    {
        public int ID { get; set; }
        public string LogTime { get; set; }
        public string IP { get; set; }

        public string Function { get; set; }

        public string Label { get; set; }

        public string ShortInfo { get; set; }
        
        public string Info { get; set; }    
        public string Stack { get; set; }

        public int Level { get; set; }
    }

    public class CallLog : BaseEntity
    {
        //UserIp, DownstreamRequest, Path, Method, QueryString, RequestBodyLength, CallTime,  Result,ConsumerTime,ResponseSize,ErrorMsg
        public int ID { get; set; }
        /// <summary>
        /// 真实访问ip
        /// </summary>
        public string DownstreamRequest { get; set; }
       // [JsonConverter(typeof(DateTimeConverter1),"yyyy-MM-dd HH:mm:ss")]
        public string CallTime { get; set; }
        public string UserIp { get; set; }

        public string Path { get; set; }

        public string Method { get; set; }

        public string QueryString { get; set; }

        public int RequestBodyLength { get; set; }
        public int Result { get; set; }

        /// <summary>
        /// 耗时毫秒
        /// </summary>
        public long ConsumerTime { get; set; }
        /// <summary>
        /// 返回体大小
        /// </summary>
        public int ResponseSize { get; set; }

        public string ErrorMsg { get; set; }
    }



    public class DateTimeConverter1 : IsoDateTimeConverter
    {
        public DateTimeConverter1() : base()
        {
            // 默认日期时间格式
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }

        public DateTimeConverter1(string format) : this()
        {
            DateTimeFormat = format;
        }

    }
}
