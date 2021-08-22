using Autofac;
using AutoMapper;
using Divergic.Configuration.Autofac;
using karachun_geo.API.Configurations.AutoMapper;
using karachun_geo.BI.Options;
using System;
using karachun_geo.BI.Interfaces;
using karachun_geo.BI.Services;

namespace karachun_geo.API.Configurations.Autofac
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Geolocations>()
                .As<IGeolocation>();

            builder.RegisterType<DataSend>()
                .As<IDataSend>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var resolver = new EnvironmentJsonResolver<Config>("appsettings.json", $"appsettings.{env}.json");
            var module = new ConfigurationModule(resolver);

            builder.RegisterModule(module);
        }
    }
}
