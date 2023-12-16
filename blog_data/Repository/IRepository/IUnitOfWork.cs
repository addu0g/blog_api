using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IPostRepository Post { get; }
        void Save();
    }
}
