using Autofac;
using PKShop.Struct.Services.Mappers;
using PKShop.Struct.Services.Services;
using System.Reflection;

namespace PKShop.Domain
{
    public static class ServicesContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var servicesAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(servicesAssembly)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(servicesAssembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterInstance(AutoMapperConfig.RegisterMappings())
                   .SingleInstance();
        }
    }
}