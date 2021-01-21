using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web
{
    public class TokenModel
    {
        public string user_token { get; set; }
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string refresh_token { get; set; }

        public string scope { get; set; }

        public int expires_in { get; set; }
    }

    public class ResponseBase<T>
    {
        /// <summary>
        /// construction
        /// </summary>
        public ResponseBase()
        {
            msg = "";
            code = 0;
        }

        public ResponseBase(T data)
        {
            code = 0;
            msg = "Ok";
            this.data = data;
        }

        public ResponseBase(int code, string message, T data)
        {
            this.code = code;
            msg = message;
            this.data = data;
        }
        /// <summary>
        /// 编码 0-成功
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }

        public void SetError(string msg)
        {
            code = -1;
            this.msg = msg;
        }

        public void SetResult(int code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }


    }


    public class AppSetting
    {
        public string IdentityServerUrl { get; set; }
        /// <summary>
        /// 是否启用网关
        /// </summary>
        public string IsGateWay { get; set; }

        public string ApiScops { get; set; }

        public string ClientId { get; set; }

        public  string Secret { get; set; }
    }
}
