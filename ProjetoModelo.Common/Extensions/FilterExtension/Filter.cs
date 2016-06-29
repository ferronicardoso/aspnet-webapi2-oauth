using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Common.Extensions.FilterExtension
{
    public class Filter
    {
        //public List<FilterItem> FilterItens { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public static Filter CreateFilterFromJson(dynamic filtersValues)
        {
            //var filterItens = new List<FilterItem>();

            //foreach (dynamic item in filtersValues.filterItens)
            //{
            //    var filterItem = new FilterItem
            //    {
            //        HeaderName = item.headerName,
            //        FieldName = item.fieldName,
            //        FieldType = item.fieldType
            //    };

            //    filterItens.Add(filterItem);
            //}

            //var filter = new Filter { FilterItens = new List<FilterItem>() };
            var filter = new Filter();
            filter.PageNumber = filtersValues.pageNumber;
            filter.PageSize = filtersValues.pageSize;
            //filter.FilterItens = filterItens;

            return filter;
        }
    }
}
