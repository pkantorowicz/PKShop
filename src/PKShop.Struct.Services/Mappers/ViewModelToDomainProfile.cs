using AutoMapper;
using PKShop.Domain.Commands.Products;
using PKShop.Struct.Services.ViewModels;

namespace PKShop.Struct.Services.Mappers
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ProductViewModel, CreateNewProductCommand>()
                .ConstructUsing(x => new CreateNewProductCommand(x.Name, x.Quantity, x.Cost));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(x => new UpdateProductCommand(x.Id, x.Name, x.Quantity, x.Cost));
        }
    }
}