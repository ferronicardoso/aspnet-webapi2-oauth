using Newtonsoft.Json;
using ProjetoModelo.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoModelo.Common.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public new HttpResponseMessage NotFound()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public new HttpResponseMessage BadRequest()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public new HttpResponseMessage BadRequest(string message)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, message);
        }

        public HttpResponseMessage BadArgument(string paramName)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, string.Format(Messages.ArgumentNull, paramName));
        }

        public HttpResponseMessage BadFormatParameter<T>(object obj)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, string.Format(Messages.InvalidArgument, JsonConvert.SerializeObject(obj)));
        }
    }
}
