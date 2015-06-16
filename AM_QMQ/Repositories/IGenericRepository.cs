﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AM_QMQ.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        ICollection<T> List();
        T SearchById(int id);
        ICollection<T> SearchFor(Expression<Func<T, bool>> filter);
    }
}