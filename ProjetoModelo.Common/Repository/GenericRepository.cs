using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Common.Repository
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

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual bool Exists(int id)
        {
            return this.GetById(id) != null;
        }

        //public IQueryable<T> FindByFilter(Filter filter, int pageNumber, int pageSize, out int pageCount, IQueryable<T> query)
        //{
        //    pageCount = query.Count();

        //    if (pageNumber > 1)
        //        query = query.Skip(pageSize * (pageNumber - 1));

        //    query = query.Take(pageSize);

        //    return query;
        //}
    }
}
