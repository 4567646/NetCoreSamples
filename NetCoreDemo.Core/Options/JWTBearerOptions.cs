using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Core.Options
{
    public class JWTBearerOptions
    {
        /// <summary>
        /// Token颁发机构
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 颁发目标
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 签名秘钥
        /// </summary>
        public string Secret { get; set; }
    }
}
