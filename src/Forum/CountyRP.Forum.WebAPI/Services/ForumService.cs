using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.WebAPI.Services.Interfaces;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services
{
    public class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private Extra.PlayerClient _playerClient;

        public ForumService(IForumRepository forumRepository,
            Extra.PlayerClient playerClient)
        {
            _forumRepository = forumRepository;
            _playerClient = playerClient;
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
