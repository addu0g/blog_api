using blog_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_services.IServices
{
    public interface ICategoryService 
    {
        IEnumerable<Post> GetCategories();
    }
}
