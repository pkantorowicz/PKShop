using System.Reflection;
using Autofac;
using MediatR;
using PKShop.Core.Notifications;
using PKShop.Domain.Events.Products;

namespace PKShop.Common.IoC.Modules
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(DomainModule)
            .GetTypeInfo()
            .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(INotificationHandler<>))
                   .InstancePerLifetimeScope();
        }
    }
}