using PKShop.Domain.DomainClasses.Products;
using PKShop.Domain.Interfaces;
using PKShop.Struct.WriteData.Contexts;

namespace PKShop.Struct.WriteData.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(PKShopContext context)
            : base(context)
        {
        }
    }
}