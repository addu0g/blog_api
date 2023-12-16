using blog_data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IPostRepository Post { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Post = new PostRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
