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

namespace Lyre.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static ContainerBuilder GenerateBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DatabaseHandler>().As<IDatabaseHandler>().SingleInstance();
            //builder.RegisterModule();

            return builder;
        }

        private static IMapper GenerateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
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
