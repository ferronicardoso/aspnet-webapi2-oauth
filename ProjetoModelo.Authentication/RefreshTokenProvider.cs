using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoModelo.Authentication
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();

        public async void Create(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();

            var token = guid.ToMD5();
            _refreshTokens.TryAdd(token, context.Ticket);
            context.SetToken(token);

            await Task.FromResult(0);
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();

            var token = guid.ToMD5();
            _refreshTokens.TryAdd(token, context.Ticket);
            context.SetToken(token);

            await Task.FromResult(0);
        }

        public async void Receive(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;
            if (_refreshTokens.TryRemove(context.Token, out ticket))
            {
                context.SetTicket(ticket);
            }

            await Task.FromResult(0);
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;
            if (_refreshTokens.TryRemove(context.Token, out ticket))
            {
                context.SetTicket(ticket);
            }

            await Task.FromResult(0);
        }
    }
}