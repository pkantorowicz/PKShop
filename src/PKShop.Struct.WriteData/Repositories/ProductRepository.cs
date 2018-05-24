using System.Linq;
using Microsoft.EntityFrameworkCore;
using PKShop.Domain.DomainClasses.Products;
using PKShop.Domain.Interfaces;
using PKShop.Struct.WriteData.Context;

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