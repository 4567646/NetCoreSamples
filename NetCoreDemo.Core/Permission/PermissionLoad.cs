
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace NetCoreDemo.Core.Permission
{
    /// <summary>
    /// 权限数据加载
    /// </summary>
    public class PermissionLoad
    {
        public static List<PermissionAttribute> GetPermissionsList()
        {
            List<PermissionAttribute> it = new List<PermissionAttribute>();
            //加载NetCoreDemo.Web程序局
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName("NetCoreDemo.Web"));
            var result = new List<PermissionAttribute>();
            var types = assembly.GetTypes();
            if (types.Length > 0)
            {
                foreach (var type in types)
                {
                    string typeName = type.FullName.ToLower();
                    if (typeName.EndsWith("controller"))
                    {
                        var perAttList = type.GetCustomAttributes<PermissionAttribute>(false);
                        PermissionAttribute perent = null;
                        if (perAttList != null & perAttList.Any())
                        {
                            foreach (var per in perAttList)
                            {
                                if (string.IsNullOrEmpty(per.SysCode))
                                    per.SysCode = type.Name.Replace("Controller", "");
                                per.Controller = type.Name;
                                //菜单添加路由为Conntroller
                                if (per.PerType == (int)PermissionEnum.Menu) {
                                    per.RouteName = per.SysCode;
                                }
                                perent = per;
                                result.Add(per);
                            }
                        }

                        //获取Action方法
                        var members = type.FindMembers(MemberTypes.Method, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField, Type.FilterName, "*");
                        if (members.Length > 0 && members.Any())
                        {
                            foreach (var mb in members)
                            {
                                var perAttList2 = mb.GetCustomAttributes<PermissionAttribute>(false);
                                foreach (var per in perAttList2)
                                {
                                    if (string.IsNullOrEmpty(per.SysCode))
                                        per.SysCode = type.Name.Replace("Controller", "") + "." + mb.Name;
                                    per.Controller = type.Name;
                                    per.Action = mb.Name;
                                    //如果父级未指定
                                    if (string.IsNullOrEmpty(per.ParentCode))
                                        if (perent != null)
                                            per.ParentCode = perent.SysCode;
                                    //获取标记了路由的方法
                                    object[] routes = mb.GetCustomAttributes(typeof(RouteAttribute), false);
                                    if (routes.Length > 0 && routes.Any())
                                    {
                                        var route = routes.First() as RouteAttribute;
                                        per.RouteName = route.Template;
                                    }
                                    else {
                                        per.RouteName = type.Name.Replace("Controller", "") + "/"+ mb.Name;
                                    }
                                    result.Add(per);
                                }
                            }
                        }
                    }


                }
            }
            return result;
        }
    }
}
