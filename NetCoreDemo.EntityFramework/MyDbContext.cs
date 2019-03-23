using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Core.Data;
using NetCoreDemo.Core.Domain.Logging;
using NetCoreDemo.Core.Domain.Sys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NetCoreDemo.EntityFrameworkCore
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
               : base(options)
        {
        }

        public DbSet<Log> Log { get; set; }
        public DbSet<Sys_Admin> Sys_Admin { get; set; }
        public DbSet<Sys_Permission> Sys_Permission { get; set; }
        public DbSet<Sys_Role> Sys_Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
