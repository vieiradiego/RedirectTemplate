using RedirectTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedirectTemplate.Repository
{
    public interface IRepository <T> where T : BaseEntityModel
    {
        T Create(T entity);
        T Update(T entity);
        bool Exists(long? id);
        void Delete(int id);
        T FindById(int id);
        List<T> FindAll();
        T Find(Expression<Func<T, bool>> expression);
    }
}
