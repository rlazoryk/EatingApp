using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace EatingApp.Core.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int Id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);        
    }
}
