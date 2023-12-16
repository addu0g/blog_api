using blog_data.Repository;
using blog_data.Repository.IRepository;
using blog_models;
using blog_services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace blog_services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<Post> Products { get; set; }
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _unitOfWork.Post.GetAll("Category");
        }

        public Post GetPost(int id)
        {
            return _unitOfWork.Post.Get(o=>o.Id == id, "Category");
        }

        public Post AddPost(Post post)
        {
            Post newPost = new Post() { Title = post.Title, Content = post.Content, CategoryId = post.CategoryId, TimeStamp = DateTime.Now };
            newPost = _unitOfWork.Post.Add(newPost);

            newPost = _unitOfWork.Post.GetAll().OrderByDescending(o => o.TimeStamp).FirstOrDefault();
            _unitOfWork.Save();
            return newPost;
        }

        public Post UpdatePost(Post post)
        {
            if (post != null)
            {
                _unitOfWork.Post.Update(post);
                _unitOfWork.Save();
            }
            return _unitOfWork.Post.Get(o => o.Id == post.Id);
        }

        public void RemovePost(int postId)
        {
            Post post = _unitOfWork.Post.Get(o => o.Id == postId);
            if (post != null)
            {
                _unitOfWork.Post.Remove(post);
                _unitOfWork.Save();
            }
        }

        public void RemovePosts()
        {
            _unitOfWork.Post.RemoveAll();
            _unitOfWork.Save();
        }
    }
}
