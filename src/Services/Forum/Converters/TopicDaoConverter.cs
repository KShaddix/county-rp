using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;

namespace CountyRP.Services.Forum.Converters
{
    public class TopicDaoConverter
    {
        public static TopicDtoOut ToRepository(
            TopicDao source
        )
        {
            return new TopicDtoOut(
                id: source.Id,
                caption: source.Caption,
                forumId: source.ForumId
            );
        }
    }
}
