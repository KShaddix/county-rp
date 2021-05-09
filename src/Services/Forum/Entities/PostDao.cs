using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class PostDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public string Text { get; }
        public int TopicId { get; }
        public int UserId { get; }
        public int LastEditorid { get; }
        public DateTime CreationDateTime { get; }
        public DateTime EditionDateTime { get; }

        public PostDao(int id,
            string text,
            int topicId,
            int userId,
            int lastEditorId,
            DateTime creationDateTime,
            DateTime editionDateTime)
        {
            Id = id;
            Text = text;
            TopicId = topicId;
            UserId = userId;
            LastEditorid = lastEditorId;
            CreationDateTime = creationDateTime;
            EditionDateTime = editionDateTime;
        }
    }
}
