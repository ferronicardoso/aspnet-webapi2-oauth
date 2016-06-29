using ProjetoModelo.Common.Extensions.FilterExtension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Exemplo.Infrastructure.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _context;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext model)
        {
            _context = model;
            _dbset = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable();
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual T GetById(long id)
        {
            return _dbset.Find(id);
        }

        public virtual void Update(long id, T newEntity)
        {
            var originalEntity = _dbset.Find(id);
            _context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
        }

        public virtual bool Exists(int id)
        {
            return this.GetById(id) != null;
        }

        public virtual bool Exists(long id)
        {
            return this.GetById(id) != null;
        }

        public IQueryable<T> FindByFilter(Filter filter, int pageNumber, int pageSize, out int pageCount, out int totalRow, IQueryable<T> query)
        {
            totalRow = query.Count();
            pageCount = GetTotalPages(totalRow, pageSize);

            if (pageNumber > 1)
                query = query.Skip(pageSize * (pageNumber - 1));

            query = query.Take(pageSize);

            return query;
        }

        public IQueryable<T> FindByPage(int pageNumber, int pageSize, out int pageCount, out int totalRow, IQueryable<T> query)
        {
            totalRow = query.Count();
            pageCount = GetTotalPages(totalRow, pageSize);

            if (pageNumber > 1)
                query = query.Skip(pageSize * (pageNumber - 1));

            query = query.Take(pageSize);

            return query;
        }

        private int GetTotalPages(int totalRows, int pageSize = 10)
        {
            var totalPages = 1;

            if (totalRows > 0)
                totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

            return totalPages;
        }
    }
}
