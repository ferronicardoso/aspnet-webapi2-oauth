using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Common.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Add(T entity);
        T Delete(T entity);
        T GetById(long id);
        void Edit(T entity);
        bool Exists(int id);

        //IQueryable<T> FindByFilter(Filter filter, int pageNumber, int pageSize, out int pageCount, IQueryable<T> query);
    }
}
