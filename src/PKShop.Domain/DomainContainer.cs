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
    public static class IndentityContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var domainAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(domainAssembly)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<DomainNotificationHandler>().As<INotificationHandler<DomainNotification>>();
            builder.RegisterType<ProductEventHandler>().As<INotificationHandler<ProductCreatedEvent>>();
            builder.RegisterType<ProductEventHandler>().As<INotificationHandler<ProductCodeUpdatedEvent>>();
            builder.RegisterType<ProductEventHandler>().As<INotificationHandler<ProductDeletedEvent>>();

            builder.RegisterType<ProductCommandHandler>().As<INotificationHandler<CreateNewProductCommand>>();
            builder.RegisterType<ProductCommandHandler>().As<INotificationHandler<UpdateProductCommand>>();
            builder.RegisterType<ProductCommandHandler>().As<INotificationHandler<DeleteProductCommand>>();
        }
    }
}