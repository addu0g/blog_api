using blog_data;
using blog_models;
using blog_services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_services
{
    public class PostService : IPostService
    {
        //private readonly IUnitOfWork _unitOfWork;
        public List<Post> Products { get; set; }
        public PostService()
        {
            //_unitOfWork = unitOfWork;
        }

        public IEnumerable<Post> GetPosts()
        {
            throw new NotImplementedException(); //_unitOfWork.Product.GetAll("Category");
        }
    }
}
