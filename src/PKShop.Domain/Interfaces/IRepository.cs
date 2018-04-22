using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PKShop.Domain.DomainClasses.Abstract;

namespace PKShop.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Guid id);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Browse();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        bool Exists(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T UpdateAsync(T entity);
        void DeleteAsync(Guid id);
        int SaveChanges();
    }
}