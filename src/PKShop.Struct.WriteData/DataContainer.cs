using Autofac;
using PKShop.Core.Events;
using PKShop.Domain.Interfaces;
using PKShop.Struct.WriteData.Context;
using PKShop.Struct.WriteData.EventSourcing;
using PKShop.Struct.WriteData.Repositories;
using PKShop.Struct.WriteData.UnitOfWork;
using System.Reflection;

namespace PKShop.Domain
{
    public static class DataContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var dataAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAssembly)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(dataAssembly)
                   .Where(x => x.IsAssignableTo<ISqlRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<PKShopContext>().InstancePerRequest();

            builder.RegisterType<EventStoreRepository>().As<IEventStoreRepository>();
            builder.RegisterType<EventStoreContext>().InstancePerRequest();
            builder.RegisterType<SqlEventStore>().As<IEventStore>();           
        }
    }
}