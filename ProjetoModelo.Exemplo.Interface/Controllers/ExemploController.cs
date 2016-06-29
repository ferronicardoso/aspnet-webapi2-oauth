using ProjetoModelo.Authentication.Domain.Entities;
using ProjetoModelo.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoModelo.Exemplo.Interface.Controllers
{
    [RoutePrefix("exemplo")]
    public class ExemploController : BaseApiController
    {
        [HttpGet]
        [Route()]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = 1, Descricao = "Projeto Web API" });
        }

        /// <summary>
        /// Exemplo de retorno de erro personalizado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("error")]
        public HttpResponseMessage GetError()
        {
            var a = 0;
            var b = 10;

            var x = b / a;

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route()]
        public HttpResponseMessage Post(User user)
        {
            if (user == null) return BadFormatParameter<User>(new User());

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
