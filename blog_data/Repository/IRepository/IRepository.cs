using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? relationships = null);
        T Get(Expression<Func<T, bool>> filter, string? relationships = null);
        T Add(T entity);
        void Remove(T entity);
        void RemoveAll();
    }
}
