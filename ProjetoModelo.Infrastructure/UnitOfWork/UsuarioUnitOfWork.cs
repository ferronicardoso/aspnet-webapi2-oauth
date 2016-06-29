using ProjetoModelo.Exemplo.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Exemplo.Infrastructure.UnitOfWork
{
    public class UsuarioUnitOfWork : ApplicationContext
    {
        private UsuarioRepository repositoryUsuario;

        public UsuarioUnitOfWork()
        {
            repositoryUsuario = new UsuarioRepository(this);
        }

        public UsuarioRepository UsuarioRepository
        {
            get { return repositoryUsuario; }
        }
    }
}
