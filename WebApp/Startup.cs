using DependencyResolution;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using System.Web.Routing;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;

            //https://blog.jayway.com/2016/01/08/improving-error-handling-asp-net-web-api-2-1-owin/
            //config.Services.Replace(typeof(IExceptionHandler), new PassthroughHandler());
            //app.Use<ExceptionHandlingMiddleware>();
            config.Routes.MapHttpRoute(
                name: "angular",
                routeTemplate: "{*url}",
                defaults: new { id = RouteParameter.Optional }
            );
            WebAppDependencyResolver.SetWebAppDependencyResolver(config, app);
            app.UseWebApi(config);
        }
    }
}