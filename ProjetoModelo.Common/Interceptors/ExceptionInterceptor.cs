using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace ProjetoModelo.Common.Interceptors
{
    public class ExceptionInterceptor : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = HandleException(actionExecutedContext);
            base.OnException(actionExecutedContext);
        }

        internal HttpResponseMessage HandleException(HttpActionExecutedContext actionExecutedContext)
        {
            string message = string.Empty;

            Exception exception = actionExecutedContext.Exception;

            var erro = exception.InnerException != null ? exception.InnerException.Message : exception.Message;
            message = "Ocorreu um erro inesperado no servidor. Erro " + erro + ".";

            return actionExecutedContext.Request.CreateErrorResponse(MapHttpStatusCode(exception), message);
        }

        private static HttpStatusCode MapHttpStatusCode(Exception exception)
        {
            if (exception is Exception)
            {
                return HttpStatusCode.BadRequest;
            }
            
            return HttpStatusCode.BadRequest;
        }
    }
}
