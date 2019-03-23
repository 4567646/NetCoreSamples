using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NetCoreDemo.Core.CodeGenerator.Options;
using NetCoreDemo.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreDemo.EntityFrameworkCore
{
    /// <summary>
    /// 仓储基类中定义的公共的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly MyDbContext _dbContext;
        private DbSet<T> dbSet;
        public EfRepository(MyDbContext myContext)
        {
            _dbContext = myContext;
        }

        #region  新增

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual void AddEntity(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            Commit();
        }

        /// <summary>
        /// 异步新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddEntityAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await CommitAsync();
        }

        /// <summary>
        /// 新增实体列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual void AddRange(IEnumerable<T> entity)
        {
            _dbContext.Set<T>().AddRange(entity);
            Commit();
        }


        /// <summary>
        /// 异步新增实体列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbContext.Set<T>().AddRangeAsync(entity);
            await CommitAsync();
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据条件查询实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual T GetEntity(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().SingleOrDefault(where);
        }
        /// <summary>
        /// 根据条件查询实体列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IEnumerable<T> WhereLoadEntitys(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where);
        }

        #endregion

        /// <summary>
        /// 获取整张表数据
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get { return this.DbSet; }
        }
        // <summary>
        /// Entities
        /// </summary>
        protected virtual DbSet<T> DbSet
        {
            get
            {
                this.dbSet = this.dbSet ?? _dbContext.Set<T>();
                return this.dbSet;
            }
        }
        /// <summary>
        /// 内存回收
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
