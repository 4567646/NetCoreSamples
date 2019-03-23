using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Web.Components
{
    public class HeadViewComponent:ViewComponent
    {
        /// <summary>
        /// 顶部组件
        /// </summary>
        /// <param name="menuType"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
