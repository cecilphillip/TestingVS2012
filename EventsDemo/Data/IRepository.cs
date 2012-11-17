using System;
using System.Linq;
using System.Linq.Expressions;

namespace EventsDemo.Data
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> All();
        IQueryable<T> Find(Expression<Func<T, bool>> exp);
        T FindSingle(Expression<Func<T, bool>> exp);
        void InsertOrUpdate(T entity);
        void Delete(int id);
        void Save();
    }
}