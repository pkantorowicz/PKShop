using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PKShop.Core.Bus;
using PKShop.Domain.Commands.Products;
using PKShop.Domain.DomainClasses.Products;
using PKShop.Domain.Interfaces;
using PKShop.Struct.Services.DTO;
using PKShop.Struct.Services.History;

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

        public async Task<ProductDTO> GetAsync(Guid id)
            => _mapper.Map<ProductDTO>(await _productRepository.GetAsync(id));

        public async Task<IEnumerable<ProductDTO>> BrowseAsync()
            => _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(await _productRepository.BrowseAsync());
        
        public Task<IEnumerable<ProductHistoryData>> GetHistoryDataAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(ProductDTO product)
        {
            var createCommand = _mapper.Map<CreateNewProductCommand>(product);
            await _bus.SendCommand(createCommand);
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(product);
            await _bus.SendCommand(updateCommand);
        }

        public async Task RemoveAsync(Guid id)
        {
            var removeCommand = new DeleteProductCommand(id);
            await _bus.SendCommand(removeCommand);
        }
    }
}