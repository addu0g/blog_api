using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Repo.IRepo
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? relationships = null);
        T Get(Expression<Func<T, bool>> filter, string? relationships = null);
        void Add(T entity);
        void Remove(T entity);
    }
}
