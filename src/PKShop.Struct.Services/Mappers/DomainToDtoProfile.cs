using AutoMapper;
using PKShop.Domain.DomainClasses.Products;
using PKShop.Struct.Services.ViewModels;

namespace PKShop.Struct.Services.Mappers
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}