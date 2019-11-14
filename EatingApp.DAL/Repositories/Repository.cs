using System;
using System.Collections.Generic;
using System.Text;
using EatingApp.Core.Abstractions.Repositories;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EatingApp.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly FoodApiContext Context;

        public Repository(FoodApiContext context)
        {
            this.Context = context;
        }

        public TEntity GetById(int Id)
        {
            return Context.Set<TEntity>().Find(Id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable();
        }
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);            
        }
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;            
        }
        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }        
    }
}
