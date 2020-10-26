using System.Threading.Tasks;
using System.Linq;

using CountyRP.Forum.Domain;
using CountyRP.Forum.Domain.Interfaces;

namespace CountyRP.Forum.Infrastructure
{
    public class ForumRepository : IForumRepository
    {
        private ForumContext _forumContext;
        public ForumRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public async Task<ForumModel> CreateForum(ForumModel forum)
        { 
            _forumContext.Forums.Add(forum);

            await _forumContext.SaveChangesAsync();

            var createdForum = _forumContext.Forums.FirstOrDefault(f => f.Id == forum.Id);

            return createdForum;
            
        }
    }
}
