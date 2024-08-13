using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BKMeCommerce.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Category
        void Add(T entity);
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Remove (T entity);
        void RemoveRange (IEnumerable<T> entities);


    }
}
