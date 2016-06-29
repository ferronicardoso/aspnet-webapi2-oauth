using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProjetoModelo.Authentication.Domain.Interfaces;
using System;

namespace ProjetoModelo.Authentication
{
    public class Authorization
    {
        public static void Configure(IAppBuilder app, IAuthApplicationService authAppService)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/security/token"),
                Provider = new AuthorizationProvider(authAppService),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new RefreshTokenProvider()
            };

            var bearerOptions = new OAuthBearerAuthenticationOptions()
            {
                AccessTokenFormat = OAuthOptions.AccessTokenFormat,
                AccessTokenProvider = OAuthOptions.AccessTokenProvider,
                AuthenticationMode = OAuthOptions.AuthenticationMode,
                AuthenticationType = OAuthOptions.AuthenticationType,
                Description = OAuthOptions.Description,
                Provider = new BearerAuthenticationProvider(),
                SystemClock = OAuthOptions.SystemClock
            };

            app.UseOAuthAuthorizationServer(OAuthOptions);

            OAuthBearerAuthenticationExtensions.UseOAuthBearerAuthentication(app, bearerOptions);
        }
    }
}