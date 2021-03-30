using ASHC.REPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASHC.REPOS.UnitOfWorkInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;

        void Save();

        Task<int> SaveAsync();

        void Dispose(bool disposing);
    }
}
