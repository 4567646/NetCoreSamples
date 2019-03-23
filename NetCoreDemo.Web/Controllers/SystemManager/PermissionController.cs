using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Core.Const;
using NetCoreDemo.Core.Enums;
using NetCoreDemo.Core.Permission;

namespace NetCoreDemo.Web.Controllers.SystemManager
{
    /// <summary>
    /// 菜单需配置所属模块(即Controller前缀)
    /// </summary>
    [Permission("权限管理", "SystemManager", (int)PermissionEnum.Menu, "fa fa-circle-o text-aqua")]
    public class PermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Permission("新增", (int)PermissionEnum.Button, CssClassConst.BtnAdd)]
        [Route("Permission/Add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        [Permission("详细", (int)PermissionEnum.Button, CssClassConst.BtnDetail)]
        public IActionResult Detail()
        {
            return View();
        }
    }
}