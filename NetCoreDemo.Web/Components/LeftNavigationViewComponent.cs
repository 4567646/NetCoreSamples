using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Core.Domain.Sys;
using NetCoreDemo.Core.Enums;
using NetCoreDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Web.Components
{
    public class LeftNavigationViewComponent : ViewComponent
    {
        private readonly ISys_PermissionService sys_PermissionService;
        public LeftNavigationViewComponent(ISys_PermissionService _sys_PermissionService) {
            sys_PermissionService = _sys_PermissionService;
        }
        /// <summary>
        /// 菜单栏组件
        /// </summary>
        /// <param name="menuType">1 -Menu(默认的) 2-Index</param>
        /// <returns></returns>
        public IViewComponentResult Invoke(int menuType)
        {
            var TypeName = "";
            var PermissionList = GetPermissionList();
            switch (menuType)
            {
                case 1: TypeName = "Navigation"; break;
                case 2: TypeName = "Index"; break;
                default: throw new ArgumentException("错误的类型");
            }
            return View(TypeName, PermissionList);
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Sys_Permission> GetPermissionList()
        {
           return sys_PermissionService.GetAll();
            
        }
    }
}
