using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Core.Enums;
using NetCoreDemo.Core.Permission;

namespace NetCoreDemo.Web.Controllers.SystemManager
{
    [Permission("系统管理", (int)PermissionEnum.Model, "glyphicon glyphicon-cog")]
    public class SystemManagerController : Controller
    {

    }
}