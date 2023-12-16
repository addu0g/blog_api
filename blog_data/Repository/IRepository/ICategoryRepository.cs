using blog_data.Repo.IRepo;
using blog_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
