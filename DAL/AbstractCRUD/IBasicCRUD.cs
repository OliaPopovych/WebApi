using System;
using System.Linq.Expressions;

namespace DataAccess.Abstractions
{
    public interface IBasicCRUD<T> : IDBLookup<T>
    {
        void Delete(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Edit(T entity);
    }
}
