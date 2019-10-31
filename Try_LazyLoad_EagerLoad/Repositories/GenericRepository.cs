﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : GeneralEntity
    {
        protected ApiDbContext _entities;
        protected readonly DbSet<T> _dbset;

        protected GenericRepository(ApiDbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }
        public ApiDbContext GetDataBase()
        {
            return _entities;

        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity).Entity;
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity).Entity;
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual int Save()
        {
            return _entities.SaveChanges();
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Any(predicate);
        }

        public bool All(Expression<Func<T, bool>> predicate)
        {
            return _dbset.All(predicate);
        }

        public IQueryable<T> FindByWithQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _dbset.First(predicate);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Count(predicate);
        }

        public int Count()
        {
            return _dbset.Count();
        }
    }
}
