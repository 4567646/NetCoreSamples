using NetCoreDemo.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Core.Domain.Sys
{
    public class Sys_Admin : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Ionic { get; set; }
        /// <summary>
        /// 角色 ,1,2,3,
        /// </summary>
        public string Role { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
