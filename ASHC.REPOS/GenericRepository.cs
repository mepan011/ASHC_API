using ASHC.DATA.Models;
using ASHC.REPOS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHC.REPOS
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly db_ashcContext _DbContext;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(db_ashcContext context)
        {
            _DbContext = context;
            this._DbSet = this._DbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                this._DbSet.Add(entity);
                return true;
            }
            catch(System.Exception ex)
            {
                return false;
            }
        }

        public void Delete(T entity)
        {
            this._DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this._DbSet.ToList();
        }
        public T GetById(int id)
        {
            return this._DbSet.Find(id);
        }

        public void Update(T entity)
        {
            this._DbSet.Attach(entity);
            this._DbContext.Entry(entity).State = EntityState.Modified;
        }

        // Fire and forget
        public IEnumerable<T> ExecuteWithStoreProcedure(string query)
        {
            return this._DbSet.FromSqlRaw(query).ToList();
        }
        public IEnumerable<T> ExecuteWithStoreProcedure(string query, params object[] parameters)
        {
            return this._DbSet.FromSqlRaw(query, parameters).ToList();
        }

        // Fire and forget (async)
        public async Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters)
        {
            await this._DbSet.FromSqlRaw(query, parameters).ToListAsync();
        }

        Task IRepository<T>.ExecuteWithStoreProcedureAsync(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
