using ProjetoModelo.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoModelo.Exemplo.Interface.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("public")]
    public class PublicController : BaseApiController
    {
        [HttpGet]
        [Route("info")]
        public HttpResponseMessage Get()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = versionInfo.FileVersion;

            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Ano = DateTime.Now.Year,
                Descricao = "Projeto Modelo de Web API com Autenticação",
                Autor = "Raphael Cardoso",
                Site = "www.raphaelcardoso.com.br",
                Versao = version
            });
        }
    }
}
