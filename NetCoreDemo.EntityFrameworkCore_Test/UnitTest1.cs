using NetCoreDemo.Core.Data;
using NetCoreDemo.Core.Domain.Sys;
using NetCoreDemo.EntityFrameworkCore;
using NetCoreDemo.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace NetCoreDemo.EntityFrameworkCore_Test
{
    public class UnitTest1 : TestBase.TestBase
    {
        //private readonly IRepository<User> _userRepository;
        private readonly ISys_AdminService userService;
        public UnitTest1()
        {
            // _dbContext = dbContext;
            //_userRepository = userRepository;
            //this.userService = _serviceProvider.GetService<IUserService>();

        }
        [Fact]
        public void Test1()
        {

            //string ss1 = AppContext.BaseDirectory;
            //var list = _menuService.GetAll();
            //Assert.True(list.Count() > 0);

        }
        [Fact]
        public void Add()
        {
            var permissions = new Collection<Sys_Permission>();
            Sys_Permission permission = new Sys_Permission() { AddTime = DateTime.Now};
            permissions.Add(permission);
            new Sys_Role() { Name = "超级管理员", IsDelete = false, Remark = "", AddTime = DateTime.Now };
            Sys_Admin user = new Sys_Admin()
            {
                Ionic = "",
                IsDisabled = false,
                AddTime = DateTime.Now,
                Name = "廖峰",
                PassWord = "1",
                Role = ",1,",
            };
            userService.CreateUser(user);
        }
    }
}
