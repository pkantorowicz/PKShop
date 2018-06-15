using Autofac;
using MediatR;
using PKShop.Core.Notifications;
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