﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();

        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);

        T Get(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
 
       
    }
}