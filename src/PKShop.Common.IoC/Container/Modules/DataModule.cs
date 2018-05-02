using System.Reflection;
using Autofac;
using PKShop.Domain.Interfaces;
using PKShop.Struct.WriteData.UnitOfWork;

namespace PKShop.Common.IoC.Modules
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(DataModule)
            .GetTypeInfo()
            .Assembly;

            builder.RegisterType<UnitOfWork>()
                   .As<IUnitOfWork>()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(IRepository<>))
                   .InstancePerLifetimeScope(); 
        }
    }
}