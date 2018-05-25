using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PKShop.Core.Bus;
using PKShop.Domain.Commands.Products;
using PKShop.Domain.DomainClasses.Products;
using PKShop.Domain.Interfaces;
using PKShop.Struct.Services.History;
using PKShop.Struct.Services.ViewModels;

namespace PKShop.Struct.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IEventStoreRepository eventStoreRepository,
            IMediatorHandler bus, IMapper mapper)
        {
            _productRepository = productRepository;
            _eventStoreRepository = eventStoreRepository;
            _bus = bus;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> GetAsync(Guid id)
            => _mapper.Map<ProductViewModel>(await _productRepository.GetAsync(id));

        public async Task<IEnumerable<ProductViewModel>> BrowseAsync()
            => _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(await _productRepository.BrowseAsync());
        
        public async Task<IEnumerable<ProductHistoryData>> GetHistoryDataAsync(Guid id)
            => ProductHistory.ProductHistoryToJson(await _eventStoreRepository.AllAsync(id));

        public async Task CreateAsync(ProductViewModel productVM)
        {
            var createCommand = _mapper.Map<CreateNewProductCommand>(productVM);
            await _bus.SendCommand(createCommand);
        }

        public async Task UpdateAsync(ProductViewModel productVM)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productVM);
            await _bus.SendCommand(updateCommand);
        }

        public async Task RemoveAsync(Guid id)
        {
            var removeCommand = new DeleteProductCommand(id);
            await _bus.SendCommand(removeCommand);
        }
    }
}