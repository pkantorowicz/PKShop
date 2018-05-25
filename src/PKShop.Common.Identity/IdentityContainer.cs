using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using PKShop.Common.Identity.Authorization;
using PKShop.Common.Identity.Models;
using PKShop.Common.Identity.Services;
using PKShop.Domain.Interfaces;
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

            builder.RegisterType<AspNetUser>().As<IUser>();

            builder.RegisterType<AuthEmailMessageSender>()
                   .As<IEmailSender>()
                   .InstancePerDependency();

            builder.RegisterType<AuthSMSMessageSender>()
                   .As<ISmsSender>()
                   .InstancePerDependency();

            builder.RegisterType<HttpContextAccessor>()
                   .As<IHttpContextAccessor>()
                   .SingleInstance();

            builder.RegisterType<ClaimsRequirementHandler>()
                   .As<IAuthorizationHandler>()
                   .SingleInstance();
        }
    }
}