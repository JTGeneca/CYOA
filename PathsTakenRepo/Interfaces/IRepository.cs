using System;
using System.Linq;
using System.Linq.Expressions;

namespace PathsTakenRepo.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> Where<T>(Func<T, bool> predicate) where T : class;
        T SingleOrDefault<T>(Func<T, bool> predicate) where T : class;
        T Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
