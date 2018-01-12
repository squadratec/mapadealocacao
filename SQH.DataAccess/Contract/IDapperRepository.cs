using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SQH.DataAccess.Contract
{
    public interface IDapperRepository<T> where T : class
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll();
    }
}
