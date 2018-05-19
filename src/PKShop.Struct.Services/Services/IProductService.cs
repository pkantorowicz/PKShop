using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PKShop.Struct.Services.History;
using PKShop.Struct.Services.ViewModels;

namespace PKShop.Struct.Services.Services
{
    public interface IProductService : IService
    {
        Task<ProductViewModel> GetAsync(Guid id);
        Task<IEnumerable<ProductViewModel>> BrowseAsync();
        Task CreateAsync(ProductViewModel product);
        Task UpdateAsync(ProductViewModel product);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<ProductHistoryData>> GetHistoryDataAsync(Guid id);
    }
}