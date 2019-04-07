using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Samples.Infrastructure.UOW
{
    public interface IWorkspace
    {
        /// <summary>
        /// 用于重构来自数据库的对象
        /// </summary>
        /// <param name="typeToGet"></param>
        /// <param name="IdValue"></param>
        /// <returns></returns>
        object GetById(Type typeToGet, object IdValue);
        /// <summary>
        /// 用于将实例与IWorkspace关联起来，以便在下次调用PersistAll()时将他们保存起来
        ///WAR:如果使用GetById()从数据库取实例则不需要此方法，因为实例已与操作单元关联
        /// </summary>
        /// <param name="o"></param>
        void MakePersistent(object o);
        /// <summary>
        /// 用于将操作单元的数据持久化到数据库中
        /// </summary>
        void PersistAll();
    }
}
