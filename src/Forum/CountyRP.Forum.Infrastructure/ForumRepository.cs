using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Infrastructure.Models;

namespace CountyRP.Forum.Infrastructure
{
    public class ForumRepository : IForumRepository
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IPostRepository _postRepository;
        private ForumContext _forumContext;

        public ForumRepository(ForumContext forumContext,
            ITopicRepository topicRepository,
            IPostRepository postRepository)
        {
            _topicRepository = topicRepository;
            _postRepository = postRepository;
            _forumContext = forumContext;
        }

        public async Task<IEnumerable<ForumModel>> GetAll()
        {
            var forums = _forumContext.Forums.Select(f => f).ToList();

            return forums;
        }

        public async Task<ForumModel> CreateForum(ForumModel forum)
        {
            _forumContext.Forums.Add(forum);

            await _forumContext.SaveChangesAsync();

            return forum;

        }

        public async Task<(Topic, Post, int)> GetForumInfo(ForumModel forum)
        {
            Post lastPost = new Post();
            Topic lastTopic = new Topic();

            var allPosts = new List<Post>();

            var topics = (await _topicRepository.GetByForumId(forum.Id)).ToArray();
            foreach (var topic in topics)
            {
                allPosts.AddRange(_postRepository.GetPosts(topic.Id)?.Result);
            }

            lastPost = allPosts?.OrderByDescending(p => p.CreationDateTime).FirstOrDefault();

            lastTopic = topics?.Where(t => t.Id == lastPost.TopicId)?.FirstOrDefault();
            int postsCount = allPosts.Count();

            if (lastPost == null || lastTopic == null)
                return (null, null, postsCount);

            return (lastTopic, lastPost, postsCount);
        }
    }
}
