using ProjetoModelo.Exemplo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Exemplo.Infrastructure.Mapping
{
    class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this
                .Property(e => e.Name)
                .IsUnicode(false);

            this
                .Property(e => e.Username)
                .IsUnicode(false);

            this
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
