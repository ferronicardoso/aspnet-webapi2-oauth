using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Common.Interface
{
    public class DataGrid<T>
    {
        public List<T> DataList { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
    }
}
