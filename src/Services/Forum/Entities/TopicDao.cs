using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class TopicDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public string Caption { get; }
        public int ForumId { get; }

        public TopicDao(int id,
            string caption,
            int forumId)
        {
            Id = id;
            Caption = caption;
            ForumId = forumId;
        }
    }
}
