using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Core.Permission
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PermissionAttribute : Attribute
    {
        public PermissionAttribute()
        {

        }
        public PermissionAttribute(string name,int perType,string cssClass)
        {
            this.Name = name;
            this.PerType = perType;
            this.CssClass = cssClass;
        }
        /// <summary>
        /// 权限特性构造函数
        /// </summary>
        /// <param name="name">权限名</param>
        /// <param name="parentCode">权限父级编码</param>
        /// <param name="perType">权限类型 1-模块 2-菜单 3-按钮</param>
        /// <param name="cssClass"></param>
        public PermissionAttribute(string name,string parentCode, int perType, string cssClass)
        {
            this.Name = name;
            this.PerType = perType;
            this.CssClass = cssClass;
            this.ParentCode = parentCode;
        }
        public string Name { get; set; }
        /// <summary>
        /// 权限类型 1-模块 2-菜单 3-按钮
        /// </summary>
        public int PerType { get; set; }
        /// <summary>
        /// 统一资源定位标识
        /// </summary>
        public string SysCode { get; set; }
        public string CssClass { get; set; }

        /// <summary>
        /// 上一级资源定位标识
        /// </summary>
        public string ParentCode { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string RouteName { get; set; }
        public int Sort { get; set; }
    }
}
