
using PKShop.Core.Commands;
using PKShop.Domain.Interfaces;
using PKShop.Struct.WriteData.Context;

namespace PKShop.Struct.WriteData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PKShopContext _context;

        public UnitOfWork(PKShopContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}