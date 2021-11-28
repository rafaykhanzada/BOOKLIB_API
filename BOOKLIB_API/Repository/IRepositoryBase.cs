using BOOKLIB_API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BOOKLIB_API.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        T Insert(T model);
        T Update(T model);
        void Delete(T model);
        IEnumerable<T> GetAll();
        T GetById(int? id);
        T GetById(Guid? id);
        IEnumerable<T> Get(Expression<Func<T, bool>> condition);
        IEnumerable<T> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);
        IPagedList<T> GetAllIPagedList(int pageIndex = 0, int pageSize = int.MaxValue);
        void InsertAll(IEnumerable<T> model);
        T GetFirst(Func<T, bool> condition);
        void UpdateAll(IEnumerable<T> model);
        void DeleteAll(IEnumerable<T> model);
    }
}
