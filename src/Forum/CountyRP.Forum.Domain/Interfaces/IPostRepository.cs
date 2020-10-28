using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Domain.Models.ViewModels;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts(int topicId);
        Task<Post> Create(Post post);
        Task<Post> Edit(PostViewModel postViewModel);
        Task Delete(int postId);
    }
}
