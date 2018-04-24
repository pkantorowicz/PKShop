using AutoMapper;

namespace PKShop.Struct.Services.Mappers
{
    public class AutoMapperConfig
    {        
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoProfile());
                cfg.AddProfile(new DtoToDomainProfile());
            });
        }
    }
}