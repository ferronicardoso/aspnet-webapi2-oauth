using ProjetoModelo.Common.Extensions.FilterExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Exemplo.Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Add(T entity);
        T Delete(T entity);
        T GetById(long id);
        void Update(long id, T newEntity);
        bool Exists(int id);

        IQueryable<T> FindByFilter(Filter filter, int pageNumber, int pageSize, out int pageCount, out int total, IQueryable<T> query);
        IQueryable<T> FindByPage(int pageNumber, int pageSize, out int pageCount, out int total, IQueryable<T> query);
    }
}
