using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using NetCoreDemo.Core.Domain.Sys;
using NetCoreDemo.Core.Permission;
using NetCoreDemo.EntityFrameworkCore;

namespace NetCoreDemo.Services
{
    public class Sys_PermissionService : EfRepository<Sys_Permission>, ISys_PermissionService
    {

        public Sys_PermissionService(MyDbContext myContext) : base(myContext)
        {
        }
        /// <summary>
        /// 添加权限列表
        /// </summary>
        /// <param name="list"></param>
        public void AddList(List<Sys_Permission> list)
        {
            base.AddRange(list);
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Sys_Permission> GetAll()
        {
            return Table.ToList();
        }
        /// <summary>
        /// 初始化权限
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]//标签应用到实例方法，相当于对当前实例加锁 lock(this)
        public void InitRegister()
        {
            List<Sys_Permission> permissionsList = new List<Sys_Permission>();
            PermissionLoad.GetPermissionsList().ForEach(item =>
            {
                permissionsList.Add(new Sys_Permission
                {
                    AddTime = DateTime.Now,
                    CssClass = item.CssClass,
                    IsDisabled = false,
                    Action = item.Action,
                    Controller = item.Controller,
                    Name = item.Name,
                    ParentCode = item.ParentCode,
                    PerType = item.PerType,
                    Route = item.RouteName,
                    Sort = item.Sort,
                    SysCode = item.SysCode

                });
            });
            if (permissionsList.Count > 0)
            {
                CheckPermission(permissionsList);
            }
        }

        /// <summary>
        /// 验证权限是否已存在，存在则忽略不新增
        /// </summary>
        private void CheckPermission(List<Sys_Permission> permissionsList)
        {
            var list = Table.ToList();
            List<string> codes = new List<string>();
            codes.AddRange(list.Select(ls => ls.SysCode).ToList());
            var newPerList = from p in permissionsList
                             where !(codes).Contains(p.SysCode)
                             select p;
            this.AddList(newPerList.ToList());
        }
    }
}
