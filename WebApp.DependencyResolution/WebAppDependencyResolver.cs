using Autofac;
using Autofac.Integration.Mvc;
using System.Linq;
using System.Reflection;

namespace WebApp.DependencyResolution
{
    public class WebAppDependencyResolver
    {
        public static void SetWebAppResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetCallingAssembly());

            builder.RegisterAssemblyTypes(Assembly.Load("WebApp.Service"))
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .InstancePerRequest();

            //builder.RegisterType<WebAppDBEntities>().AsSelf().InstancePerRequest();



            var container = builder.Build();

            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}