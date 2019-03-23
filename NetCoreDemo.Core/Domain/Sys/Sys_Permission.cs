using NetCoreDemo.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Core.Domain.Sys
{
    public class Sys_Permission : BaseEntity
    {
        public string Name { get; set; }
        public string CssClass { get; set; }

        /// <summary>
        /// 统一资源定位标识
        /// </summary>
        public string SysCode { get; set; }
        /// <summary>
        /// 上一级资源定位标识
        /// </summary>
        public string ParentCode { get; set; }
        public int Sort { get; set; }
        /// <summary>
        /// 权限类型 1:模块 2:菜单栏 3:按钮 
        /// </summary>
        public int PerType { get; set; }
        public bool IsDisabled { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Route { get; set; }
        public DateTime AddTime { get; set; }
    }
}
