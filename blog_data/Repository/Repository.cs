using blog_data.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? relationships = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrWhiteSpace(relationships))
            {
                foreach (string entity in relationships.Split(new char[] { ',' },
                                            StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(entity);
                }
            }
            query = query.Where<T>(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? relationships = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrWhiteSpace(relationships))
            {
                foreach (string entity in relationships.Split(new char[] { ',' },
                                            StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(entity);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
