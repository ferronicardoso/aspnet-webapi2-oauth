using AutoMapper;
using ProjetoModelo.Common.Extensions.FilterExtension;
using ProjetoModelo.Exemplo.Domain.Dto.Usuario;
using ProjetoModelo.Exemplo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Exemplo.Infrastructure.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>
    {
        private ApplicationContext context { get; set; }

        static UsuarioRepository()
        {
            Mapper.CreateMap<Usuario, UsuarioDto>();
            Mapper.CreateMap<Usuario, UsuarioGridDto>();
        }

        public UsuarioRepository(ApplicationContext context)
            : base(context)
        {
            this.context = context;
        }

        public List<UsuarioGridDto> FindByFilter(Filter filter, int pageNumber, int pageSize, out int pageCount, out int totalRows)
        {
            var query = context.Usuario
                               .AsNoTracking()
                               .OrderBy(x => x.Id)
                               .AsQueryable();

            query = this.FindByFilter(filter, pageNumber, pageSize, out pageCount, out totalRows, query);

            var model = Mapper.Map<List<Usuario>, List<UsuarioGridDto>>(query.ToList());

            return model;
        }

        public List<Usuario> FindByPage(int pageNumber, int pageSize, out int pageCount, out int totalRows)
        {
            var query = context.Usuario.AsNoTracking()
                                       .OrderBy(x => x.Id)
                                       .AsQueryable();

            query = this.FindByPage(pageNumber, pageSize, out pageCount, out totalRows, query);

            return query.ToList();
        }

        public List<UsuarioDto> FindAll()
        {
            var model = context.Usuario
                               .AsNoTracking()
                               .ToList();

            return Mapper.Map<List<Usuario>, List<UsuarioDto>>(model);
        }
    }
}
