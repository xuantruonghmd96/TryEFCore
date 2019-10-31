using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.Services
{
    public interface IEntityService<T> where T : GeneralEntity
    {
        T Create(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindByWithQueryable(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
    }
}
