using NetCoreDemo.Core.Dependency;
using NetCoreDemo.Core.Domain.Sys;
using NetCoreDemo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Services
{
    public interface ISys_AdminService: ISingletonDependency 
    {
        void CreateUser(Sys_Admin user);

        void UpdateUser(Sys_Admin user);

        Sys_Admin GetUser(string userName);

        Sys_Admin GetUser(int id);
        IEnumerable<Sys_Admin> GetAllAdmin();

        void DeleteUser(Sys_Admin user);

        void DeleteUser(int id);

        bool ValidateUser(string userName, string password);
        
    }
}
