using NetCoreDemo.Core.Dependency;
using NetCoreDemo.Core.Domain.Sys;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Services
{
    public interface ISys_PermissionService: ISingletonDependency 
    {
        /// <summary>
        /// 添加权限列表
        /// </summary>
        /// <param name="list"></param>
        void AddList(List<Sys_Permission> list);
        /// <summary>
        /// 初始化权限
        /// </summary>
        void InitRegister();
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        IEnumerable<Sys_Permission> GetAll();
    }
}
