using Microsoft.Extensions.Options;
using NetCoreDemo.Core.CodeGenerator.Options;
using NetCoreDemo.Core.Data;
using NetCoreDemo.Core.Domain.Sys;
using NetCoreDemo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreDemo.Services
{
    public class Sys_AdminService : EfRepository<Sys_Admin>, ISys_AdminService
    {
        public Sys_AdminService(MyDbContext myContext) : base(myContext)
        {
        }

        public void CreateUser(Sys_Admin user)
        {
            AddEntity(user);
            //userRepository.AddEntity(user);
        }

        public void DeleteUser(Sys_Admin user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Sys_Admin GetUser(string userName)
        {
            return GetEntity(md => md.Name == userName);
        }

        public Sys_Admin GetUser(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取所有管理员数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Sys_Admin> GetAllAdmin()
        {
            return base.Table.ToList();
        }
        public Sys_Admin GetUserByWeChatOpenID(string weChatOpenId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Sys_Admin user)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string userName, string password)
        {
            var model = GetUser(userName);
            if (model == null) { return false; }
            else if (model.PassWord == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
