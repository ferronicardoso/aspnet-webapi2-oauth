using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using ProjetoModelo.Authentication.Domain.Interfaces;
using ProjetoModelo.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoModelo.Authentication
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private IAuthApplicationService _authAppService;

        public AuthorizationProvider(IAuthApplicationService authAppService)
        {
            _authAppService = authAppService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            await Task.FromResult(context.Validated());
        }

        public override async Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            await Task.FromResult(context.Validated());
        }

        public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            if (context.IsTokenEndpoint && context.Request.Method == "OPTIONS")
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "authorization" });
                context.RequestCompleted();
                return Task.FromResult(0);
            }
            
            return base.MatchEndpoint(context);
        }

        public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            await Task.FromResult(0);
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var identity = new ClaimsIdentity(context.Ticket.Identity);
            var ticket = new AuthenticationTicket(identity, context.Ticket.Properties);
            
            await Task.FromResult(context.Validated(ticket));
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string _username = context.UserName;
            string _password = context.Password;

            try
            {
                _password = _password.ToMD5();

                var user = _authAppService.Authentication(_username, _password);
                
                if (user == null)
                {
                    context.SetError("invalid_grant", Messages.InvalidCredential);
                    return;
                }
                else
                {
                    _authAppService.UpdateLastAccess(user.Id);
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "userId", user.Id.ToString() },
                    { "userName", user.Username }
                });

                var ticket = new AuthenticationTicket(identity, props);
                
                await Task.FromResult(context.Validated(ticket));
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
            }
        }
    }
}