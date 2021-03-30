using ASHC.DATA.Models;
using ASHC.REPOS.Interfaces;
using ASHC.REPOS.UnitOfWorkInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHC.REPOS
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly db_ashcContext _context;
        private bool _disposed;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private Guid _objectId;

        public UnitOfWork(db_ashcContext context)
        {
            _context = context;
            _objectId = Guid.NewGuid();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as GenericRepository<T>;
            }
            GenericRepository<T> repo = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }

        }
        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {
                throw e;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();

            }
            _disposed = true;
        }

        IRepository<T> IUnitOfWork.Repository<T>()
        {
            throw new NotImplementedException();
        }

        Task<int> IUnitOfWork.SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
