using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedirectTemplate.Repository.MySQL
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntityModel
    {
        private readonly MySQLContext _mySQLContext;
        public BaseRepository(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }
        public T Create(T entity)
        {
            try
            {
                _mySQLContext.Add(entity);
                _mySQLContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }
        public T Update(T entity)
        {
            if (!Exists(entity.Id)) throw new NotSupportedException("Can not update inexist item");
            var result = _mySQLContext.Set<T>().SingleOrDefault(p => p.Id.Equals(entity.Id));
            if (result != null)
            {
                try
                {
                    _mySQLContext.Entry(result).CurrentValues.SetValues(entity);
                    _mySQLContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return entity;
        }
        public bool Exists(long? id)
        {
            return _mySQLContext.Set<T>().Any(p => p.Id.Equals(id));
        }
        public void Delete(int id)
        {
            var result = _mySQLContext.Set<T>().SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _mySQLContext.Set<T>().Remove(result);
                    _mySQLContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public T FindById(int id) => _mySQLContext.Set<T>().FirstOrDefault(p => p.Id.Equals(id));
        public List<T> FindAll() => _mySQLContext.Set<T>().ToList();
        public T Find(Expression<Func<T, bool>> expression) => _mySQLContext.Set<T>().FirstOrDefault(expression);
    }
}
