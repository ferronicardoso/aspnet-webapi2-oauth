using ProjetoModelo.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoModelo.Interface.Controllers
{
    [RoutePrefix("public"), AllowAnonymous]
    public class PublicController : BaseApiController
    {
        private PublicUnitOfWork unitOfWork { get; set; }

        static PublicController()
        {
            MapHelper.Map<Pagina, PaginaMenuDto>()
                .ForMember(m => m.Titulo, o => o.MapFrom(x => x.Titulo))
                .ForMember(m => m.Link, o => o.MapFrom(x => x.Url));
        }

        public PublicController(PublicUnitOfWork _uow)
        {
            unitOfWork = _uow;
        }

        protected override void Dispose(bool disposing)
        {
            if (unitOfWork != null)
                unitOfWork.Dispose();

            base.Dispose(disposing);
        }

        [Route("version")]
        [HttpGet]
        public HttpResponseMessage GetVersion()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = versionInfo.FileVersion;

            return Request.CreateResponse(HttpStatusCode.OK, new { Version = version });
        }
    }
}
