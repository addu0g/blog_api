using blog_data.Repository.IRepository;
using blog_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        ApplicationDbContext _db;
        public PostRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Post obj)
        {
            _db.Update(obj);    
        }
    }
}
