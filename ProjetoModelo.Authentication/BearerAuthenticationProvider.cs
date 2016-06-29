using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Authentication
{
    public class BearerAuthenticationProvider : OAuthBearerAuthenticationProvider
    {
        public override Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            var claims = context.Ticket.Identity.Claims;
            if (claims.Count() == 0 || claims.Any(claim => claim.Issuer != "LOCAL AUTHORITY")) context.Rejected();
            return Task.FromResult<object>(null);
        }
    }
}
