using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PKShop.Struct.Services.DTO;
using PKShop.Struct.Services.History;

namespace PKShop.Struct.Services.Services
{
    public interface IProductService : IService
    {
        Task<ProductDTO> GetAsync(Guid id);
        Task<IEnumerable<ProductDTO>> BrowseAsync();
        Task CreateAsync(ProductDTO product);
        Task UpdateAsync(ProductDTO product);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<ProductHistoryData>> GetHistoryDataAsync(Guid id);
    }
}