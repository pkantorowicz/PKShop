using Autofac;
using AutoMapper;
using PKShop.Common.IoC.Modules;

namespace PKShop.Common.IoC
{
    public class AutofacContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<MapperModule>();
            builder.RegisterModule<ServicesModule>();
        }
    }
}

