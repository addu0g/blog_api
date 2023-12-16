using blog_data.Repository.IRepository;
using blog_models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        [HttpGet(Name = "get")]
        public Post Get(int postId)
        {
            return _unitOfWork.Post.Get(o => o.Id == postId, "Category");
        }

        [HttpHead(Name = "posts")]
        public IEnumerable<Post> GetAll()
        {
            return _unitOfWork.Post.GetAll("Category");
        }

        [HttpPost(Name = "new")]
        public Post NewPost(string title, string content, int categoryId)
        {

            Post newPost = new Post() { Title = title, Content = content, CategoryId = categoryId, TimeStamp = DateTime.Now };
            _unitOfWork.Post.Add(newPost);
            return newPost;
        }

        [HttpPut(Name = "update")]
        public Post UpdatePost(int? postId, string title, string content, int categoryId)
        {
            Post postToUpdate = _unitOfWork.Post.Get(o => o.Id == postId, "Category");
            if(postToUpdate!= null)
            {
                postToUpdate.Title = title;
                postToUpdate.Content = content;
                postToUpdate.CategoryId = categoryId;
                _unitOfWork.Post.Update(postToUpdate);
            }
            return postToUpdate;
        }

        [HttpDelete(Name = "delete")]
        public void DelPost(int postId)
        {
            Post postToUpdate = _unitOfWork.Post.Get(o => o.Id == postId, "Category");
            if (postToUpdate != null)
            {
                _unitOfWork.Post.Remove(postToUpdate);
            }
        }
    }
}
