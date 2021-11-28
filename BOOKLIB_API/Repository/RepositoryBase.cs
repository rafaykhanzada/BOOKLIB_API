using BOOKLIB_API.DataContext;
using BOOKLIB_API.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BOOKLIB_API.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context) { _context = context; }

        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().AsNoTracking().Where(condition);
        }

        public T GetFirst(Func<T, bool> condition)
        {
            return _context.Set<T>().AsNoTracking().Where(condition).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _context.Set<T>().AsNoTracking();
            return new PagedList<T>(query.ToList(), pageIndex, pageSize);
        }

        public IPagedList<T> GetAllIPagedList(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _context.Set<T>().AsNoTracking();
            return new PagedList<T>(query, pageIndex, pageSize);
        }

        public T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetById(Guid? id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Insert(T model)
        {
            var result = _context.Set<T>().Add(model);
            return result.Entity;
        }

        public void InsertAll(IEnumerable<T> model)
        {
            _context.Set<T>().AddRange(model);
        }

        public void UpdateAll(IEnumerable<T> model)
        {
            if (model.Count() > 0) { _context.Set<T>().UpdateRange(model); }
        }

        public T Update(T model)
        {
            var result = _context.Set<T>().Update(model);
            return result.Entity;
        }

        public void DeleteAll(IEnumerable<T> model)
        {
            if (model.Count() > 0) { _context.Set<T>().RemoveRange(model); }
        }
    }
}
