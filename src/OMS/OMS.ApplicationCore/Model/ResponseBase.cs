
namespace OMS.ApplicationCore
{
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
}
