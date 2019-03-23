using NetCoreDemo.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreDemo.Core.Data
{
    /// <summary>
    /// 仓储基类中定义的公共的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> : ISingletonDependency, IUnitOfWork, IDisposable where T : class
    {
        #region 新增

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void AddEntity(T entity);

        /// <summary>
        /// 异步新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddEntityAsync(T entity);

        /// <summary>
        /// 新增实体列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void AddRange(IEnumerable<T> entity);

        /// <summary>
        /// 异步新增实体列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<T> entity);

        #endregion

        #region 查询
        /// <summary>
        /// 根据条件查询实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T GetEntity(Expression<Func<T, bool>> where);
        /// <summary>
        /// 根据条件查询实体列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<T> WhereLoadEntitys(Expression<Func<T, bool>> where);
        #endregion


    }
}
