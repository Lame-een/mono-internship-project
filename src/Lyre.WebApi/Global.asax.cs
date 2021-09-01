using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Lyre.Common;
using Lyre.Model;
using Lyre.WebApi.Controllers;

namespace Lyre.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static ContainerBuilder GenerateBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<DatabaseHandler>().As<IDatabaseHandler>().SingleInstance();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new Service.DIModule());
            builder.RegisterModule(new Repository.DIModule());

            return builder;
        }

        private static IMapper GenerateMapper()
        {
            //this is temporary! - use profiles
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Song, SongController.SongREST>();
                cfg.CreateMap<Album, AlbumController.AlbumREST>();
                //cfg.CreateMap<src, dest>();
            }
            );

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
        protected void Application_Start()
        {
            ContainerBuilder builder = GenerateBuilder();
            IMapper mapper = GenerateMapper();
            builder.Register(c => mapper).As<IMapper>().InstancePerLifetimeScope();

            var container = builder.Build();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
