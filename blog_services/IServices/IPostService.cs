using blog_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_services.IServices
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        Post GetPost(int post);
        Post AddPost(Post post);

        Post UpdatePost(Post post);
        void RemovePost(int postId);
        void RemovePosts();
    }
}
