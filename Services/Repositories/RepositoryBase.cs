using DAL.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ConstructionWasteDBContext Context { get; set; }

        public RepositoryBase(ConstructionWasteDBContext context)
        {
            this.Context = context;
        }

        public void Create(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return this.Context.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression);
        }

        public T Get(int id)
        {
            return this.Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
        }

       
    }
}
