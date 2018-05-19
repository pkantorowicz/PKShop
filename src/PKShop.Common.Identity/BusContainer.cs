using Autofac;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace PKShop.Common.Identity
{
    public static class IndentityContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var identityAssemby = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(identityAssemby)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<HttpContextAccessor>()
                   .As<IHttpContextAccessor>()
                   .SingleInstance();
        }
    }
}