using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Domain.Models.ViewModels;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetByForumId(int forumId);
        Task<Topic> CreateTopic(Topic topic);
        Task<Topic> Edit(TopicViewModel topicViewModel);
        Task Delete(int id);
    }
}
