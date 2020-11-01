using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.Services.Interfaces;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services
{
    public class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private readonly ITopicRepository _topicRepository;
        private Extra.PlayerClient _playerClient;

        public ForumService(IForumRepository forumRepository,
            ITopicRepository topicRepository,
            Extra.PlayerClient playerClient)
        {
            _forumRepository = forumRepository;
            _topicRepository = topicRepository;
            _playerClient = playerClient;
        }

        public async Task<ForumModel> CreateForum(ForumModel forum)
        {
            var createdForum = await _forumRepository.CreateForum(forum);

            return createdForum;
        }

        public async Task<IEnumerable<ForumModel>> GetAllForums()
        {
            var forums = await _forumRepository.GetAll();

            return forums;
        }

        public async Task<IEnumerable<Topic>> GetTopicsByForumId(int id)
        {
            var topics = await _topicRepository.GetByForumId(id);

            return topics;
        }

        public async Task<IEnumerable<ForumInfoViewModel>> GetForumsInfo()
        {
            var forumInfos = new List<ForumInfoViewModel>();
            var forums = await _forumRepository.GetAll();

            foreach (var forum in forums)
            {
                var (lastTopic, lastPost, postsCount) = await _forumRepository.GetForumInfo(forum);

                var player = await _playerClient.GetByIdAsync(lastPost.UserId);

                forumInfos.Add(new ForumInfoViewModel
                {
                    Id = forum.Id,
                    Name = forum.Name,
                    LastTopic = new TopicViewModel_v2
                    {
                        Id = lastTopic.Id,
                        Name = lastTopic.Caption,
                        Player = new PlayerViewModel
                        {
                            Id = player.Id,
                            Login = player.Login
                        }
                    },
                    PostsCount = postsCount,
                    DateTime = lastPost.CreationDateTime
                });
            }

            return forumInfos;
        }

    }
}
