using PKShop.Domain.Interfaces;
using PKShop.Struct.WriteData.Contexts;
using System.Threading.Tasks;

namespace PKShop.Struct.WriteData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PKShopContext _context;

        public UnitOfWork(PKShopContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}