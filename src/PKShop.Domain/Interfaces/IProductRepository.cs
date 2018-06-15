using System.Threading.Tasks;
using PKShop.Domain.DomainClasses.Products;

namespace PKShop.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>, ISqlRepository
    {
    }
}