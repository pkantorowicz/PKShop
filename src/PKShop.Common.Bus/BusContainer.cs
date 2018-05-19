using Autofac;
using PKShop.Core.Bus;
using System.Reflection;

namespace PKShop.Common.Bus
{
    public static class BusContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var busAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(busAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<InMemoryBus>().As<IMediatorHandler>();       
        }
    }
}