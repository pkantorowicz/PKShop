using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PKShop.Domain.DomainClasses.Abstract;
using PKShop.Domain.Interfaces;
using PKShop.Struct.WriteData.Context;

namespace PKShop.Struct.WriteData.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PKShopContext _context;
        private readonly DbSet<T> _entity;

        public Repository(PKShopContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task<T> GetAsync(Guid id)
            => await _entity.FindAsync(id);

        public T Get(Guid id)
            => _entity.Find(id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
            => await _entity.FindAsync(predicate);

        public T Get(Expression<Func<T, bool>> predicate)
            => _entity.Find(predicate);

        public async Task<IEnumerable<T>> BrowseAsync()
            => await _entity.ToListAsync();

        public IEnumerable<T> Browse()
            => _entity.ToList();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _entity.AsQueryable().Where(predicate).ToListAsync();

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
            => _entity.AsQueryable().Where(predicate).ToList();

        public async Task CreateAsync(T entity)
            => await _entity.AddAsync(entity);

        public void Create(T entity)
            => _entity.Add(entity);

        public void Update(T entity)
            => _entity.Update(entity);

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            _entity.Remove(entity);
        }

        public void Delete(Guid id)
        {
            var entity = Get(id);
            _entity.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();


        public int SaveChanges()
            => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}