using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreDemo.Core.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}