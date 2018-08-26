using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using WebApp.Data;
using WebApp.Services;
using WebApp.Services.Interfaces;

namespace DependencyResolution
{
    public class WebAppDependencyResolver
    {
        public static void SetWebAppDependencyResolver(HttpConfiguration config, IAppBuilder app)
        {
            //load necessary assemblies
            var ts = typeof(BookService);
            var tsi = typeof(IBookService);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetCallingAssembly());

            builder.RegisterAssemblyTypes(Assembly.Load("WebApp.Services"))
                      .Where(t => t.Name.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerRequest();

            builder.RegisterType<WebAppDBEntities>().AsSelf().InstancePerRequest();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
        }
    }
}
