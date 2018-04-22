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
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
        int SaveChanges();
    }
}