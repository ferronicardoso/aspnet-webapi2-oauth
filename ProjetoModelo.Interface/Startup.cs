using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using ProjetoModelo.Authentication;
using ProjetoModelo.Authentication.Infrastructure;
using ProjetoModelo.Common.Helpers;
using ProjetoModelo.Common.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(ProjetoModelo.Interface.Startup))]

namespace ProjetoModelo.Interface
{
    public partial class Startup
    {
        public static UnityContainer container { get; private set; }

        static Startup()
        {
            container = new UnityContainer();
            DependencyResolver.Resolve(container);
        }

        public void Configuration(IAppBuilder app)
        {
            Authorization.Configure(app, new AuthApplicationService());

            HttpConfiguration config = new HttpConfiguration();
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.DependencyResolver = new UnityResolver(container);

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(name: "ApiRoute", routeTemplate: "{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            config.EnableCors();

            config.Filters.Add(new ExceptionInterceptor());
            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }
    }
}