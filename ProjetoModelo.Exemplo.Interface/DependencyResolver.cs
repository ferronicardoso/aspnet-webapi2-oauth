using Microsoft.Practices.Unity;
using ProjetoModelo.Exemplo.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModelo.Exemplo.Interface
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<UsuarioUnitOfWork>();
            container.RegisterType<PublicUnitOfWork>();
        }
    }
}