using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.ApplicationCore
{
    public class Q_SysProduct
    {
        public string productName { get; set; }

        public string environment { get; set; }
        /// <summary>
        /// true时不进行跟踪，适合删除，修改
        /// </summary>
        public bool IsAsTrack { get; set; }
        /// <summary>
        /// 多个id之间用逗号隔开
        /// </summary>
        public string ids { get; set; }
    }
}
