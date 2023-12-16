using blog_data.Repository.IRepository;
using blog_models;
using blog_services;
using blog_services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IEnumerable<Post> GetAll()
        {
            return _postService.GetPosts();
        }

        [HttpGet("int/{postId:int}")]
        public Post GetById(int postId)
        {
            return _postService.GetPost(postId);
        }

        [HttpPost(Name = "new")]
        public Post NewPost(string title, string content, int categoryId)
        {
            return _postService.AddPost(new Post() { Title = title, Content = content, CategoryId = categoryId });
        }

        [HttpPut(Name = "update")]
        public Post UpdatePost(int postId, string title, string content, int categoryId)
        {
            Post postToUpdate = _postService.GetPost(postId);
            if (postToUpdate != null)
            {
                postToUpdate.Title = title;
                postToUpdate.Content = content;
                postToUpdate.CategoryId = categoryId;
                postToUpdate = _postService.UpdatePost(postToUpdate);
            }
            return postToUpdate;
        }

        [HttpDelete]
        public void DelAllPost()
        {
            _postService.RemovePosts();
        }

        [HttpDelete("int/{postId:int}")]
        public void DelPost(int postId)
        {
            _postService.RemovePost(postId);
        }


    }
}
