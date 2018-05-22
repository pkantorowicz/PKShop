using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PKShop.Struct.Services.Mappers;
using System;

namespace PKShop.Web.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();
        }
    }
}