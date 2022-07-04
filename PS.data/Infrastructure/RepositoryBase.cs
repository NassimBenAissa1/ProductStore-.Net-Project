using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
//implementation generique de methode de crud
namespace PS.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDataBaseFactory _dbFactory;
        DbSet<T> dbset { get { return _dbFactory.DataContext.Set<T>(); } }
        public RepositoryBase(IDataBaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            _dbFactory.DataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();


            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return dbset.AsEnumerable();
        }
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null)
        {
            IQueryable<T> mydbset = dbset;
            if (condition != null)
                mydbset = mydbset.Where(condition);
            return mydbset.AsEnumerable();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }

}
