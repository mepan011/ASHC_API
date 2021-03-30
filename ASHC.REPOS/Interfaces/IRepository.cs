using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace ASHC.REPOS.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> ExecuteWithStoreProcedure(string query);
        IEnumerable<T> ExecuteWithStoreProcedure(string query, params object[] parameters);
        Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters);
    }
}
