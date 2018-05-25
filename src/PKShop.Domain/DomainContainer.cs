using Autofac;
using MediatR;
using PKShop.Core.Notifications;
using PKShop.Domain.CommandHandlers;
using PKShop.Domain.Commands.Products;
using PKShop.Domain.EventHandlers.Products;
using PKShop.Domain.Events.Products;
using System.Reflection;

namespace PKShop.Domain
{
    public static class DomainContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var domainAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(domainAssembly)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(domainAssembly)
                .Where(x => x.Name.EndsWith("Handler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<DomainNotificationHandler>()
                   .As<INotificationHandler<DomainNotification>>();
        }
    }
}