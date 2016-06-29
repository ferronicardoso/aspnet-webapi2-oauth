using System;

namespace ProjetoModelo.Exemplo.Domain.Dto.Usuario
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
    }
}
