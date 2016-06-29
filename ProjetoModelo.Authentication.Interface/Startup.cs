using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProjetoModelo.Authentication.Infrastructure;
using ProjetoModelo.Common.Interceptors;
using System.Web.Http;

[assembly: OwinStartup(typeof(ProjetoModelo.Authentication.Interface.Startup))]

namespace ProjetoModelo.Authentication.Interface
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Authorization.Configure(app, new AuthApplicationService());

            HttpConfiguration config = new HttpConfiguration();
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            
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