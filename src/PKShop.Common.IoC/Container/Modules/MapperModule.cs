using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;

namespace PKShop.Common.IoC.Modules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                   .Where(x => typeof(Profile).IsAssignableFrom(x) && !x.IsAbstract && !x.IsPublic)
                   .As<Profile>();

            builder.Register(x => new MapperConfiguration(cfg =>
            {
                foreach (var profile in x.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(x => x.Resolve<MapperConfiguration>()
                   .CreateMapper(x.Resolve))
                   .As<IMapper>()
                   .InstancePerLifetimeScope();
        }
    }
}