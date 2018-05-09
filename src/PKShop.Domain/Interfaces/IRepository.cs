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
        Task<T> GetAsync(Guid id);
        T Get(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Browse();
        Task<IEnumerable<T>> BrowseAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}