﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SQH.DataAccess.Contract
{
    public interface IDapperRepository<T> where T : class
    {
        void Add(T item);
        void Remove(T item);
        void Remove(T item, string conditions, object parameters = null);
        void Update(T item);
        void Update(T item, string conditions);
        T FindByID(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll();
        IEnumerable<T> GetList(string conditions, object parameters = null);
    }
}
