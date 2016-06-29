using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Exemplo.Domain.Dto.Usuario
{
    public class UsuarioGridDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
    }
}
