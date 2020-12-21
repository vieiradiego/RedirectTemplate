using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedirectTemplate.Repository.MongoDB
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntityModel
    {
        private readonly MongoDBContext _mongoDBContext;
        public BaseRepository(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }
        public T Create(T entity)
        {
            try
            {
                _mongoDBContext.Add(entity);
                _mongoDBContext.SaveChanges();
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
            var result = _mongoDBContext.Set<T>().SingleOrDefault(p => p.Id.Equals(entity.Id));
            if (result != null)
            {
                try
                {
                    _mongoDBContext.Entry(result).CurrentValues.SetValues(entity);
                    _mongoDBContext.SaveChanges();
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
            return _mongoDBContext.Set<T>().Any(p => p.Id.Equals(id));
        }
        public void Delete(int id)
        {
            var result = _mongoDBContext.Set<T>().SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _mongoDBContext.Set<T>().Remove(result);
                    _mongoDBContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public T FindById(int id) => _mongoDBContext.Set<T>().FirstOrDefault(p => p.Id.Equals(id));
        public List<T> FindAll() => _mongoDBContext.Set<T>().ToList();
        public T Find(Expression<Func<T, bool>> expression) => _mongoDBContext.Set<T>().FirstOrDefault(expression);
    }
}
