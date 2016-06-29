using ProjetoModelo.Exemplo.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Exemplo.Infrastructure.UnitOfWork
{
    public class PublicUnitOfWork : ApplicationContext
    {
        private UsuarioRepository repositoryUsuario;

        public PublicUnitOfWork()
        {
            repositoryUsuario = new UsuarioRepository(this);
        }
        
        public UsuarioRepository UsuarioRepository
        {
            get { return repositoryUsuario; }
        }
    }
}
