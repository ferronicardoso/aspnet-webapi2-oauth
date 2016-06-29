using ProjetoModelo.Common.Controllers;
using ProjetoModelo.Common.Extensions.FilterExtension;
using ProjetoModelo.Common.Interface;
using ProjetoModelo.Exemplo.Domain.Dto.Usuario;
using ProjetoModelo.Exemplo.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ProjetoModelo.Exemplo.Interface.Controllers
{
    [RoutePrefix("usuario")]
    public class UsuarioController : BaseApiController
    {
        private UsuarioUnitOfWork unitOfWork { get; set; }

        static UsuarioController()
        {

        }

        public UsuarioController(UsuarioUnitOfWork _uow)
        {
            unitOfWork = _uow;
        }

        protected override void Dispose(bool disposing)
        {
            if (unitOfWork != null)
                unitOfWork.Dispose();

            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("filter")]
        public HttpResponseMessage FindByFilter([ModelBinder(typeof(FilterModelBinder))] Filter filter)
        {
            int pageCount = 0;
            int totalRows = 0;
            int pageSize = filter.PageSize;
            var model = unitOfWork.UsuarioRepository.FindByFilter(filter, filter.PageNumber, pageSize, out pageCount, out totalRows);

            var grid = new DataGrid<UsuarioGridDto>()
            {
                DataList = model,
                PageCount = pageCount,
                PageSize = pageSize,
                TotalRows = totalRows
            };

            return Request.CreateResponse(HttpStatusCode.OK, grid);
        }

        [Route()]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var model = unitOfWork.UsuarioRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, model.ToList());
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            if (id == 0) BadRequest();

            var model = unitOfWork.UsuarioRepository.GetById(id);

            if (model == null) NotFound();

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}
