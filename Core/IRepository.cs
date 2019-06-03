using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core
{
    public interface IRepository<T> where T : class
    {
        //  IQueryable<T> List();
        //IQueryable<T> List(int id);
        //  Task Insert(T entity);
        // Task Update(T entity, object key);
        //  Task Delete(T entity);
        // Task DeleteById(int id);
        //  Task Remove(T entity);
        // void SaveChanges();

        List<T> List();
        List<T> List(Expression<Func<T, bool>> where);
        void Insert(T obj);
        void Update(T obj);
        IQueryable<T> ListQueryable();
        void Delete(T obj);
        T Find(Expression<Func<T, bool>> where);
        void SaveChanges();
    }
}
