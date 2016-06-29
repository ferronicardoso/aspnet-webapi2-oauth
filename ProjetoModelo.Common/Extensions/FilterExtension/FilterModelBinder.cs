using Newtonsoft.Json;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace ProjetoModelo.Common.Extensions.FilterExtension
{
    public class FilterModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Filter))
            {
                return false;
            }

            string body = actionContext.Request.Content.ReadAsStringAsync().Result;

            if (body == null)
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, "Parametros 'filter' não encontrado");
                return false;
            }



            dynamic filtersValues = JsonConvert.DeserializeObject(body);

            if (filtersValues == null)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Tipos incompativeis, esperado");
                return false;
            }

            var filter = Filter.CreateFilterFromJson(filtersValues);
            bindingContext.Model = filter;
            return true;
        }
    }
}
