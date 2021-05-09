﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class ModeratorDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public int EntityId { get; }
        public int EntityType { get; }
        public int ForumId { get; }
        public bool CreateTopics { get; }
        public bool CreatePosts { get; }
        public bool Read { get; }
        public bool EditPosts { get; }
        public bool DeleteTopics { get; }
        public bool DeletePosts { get; }

        public ModeratorDao(int id,
            int entityId,
            int entityType,
            int forumId,
            bool createTopics,
            bool createPosts,
            bool read,
            bool editPosts,
            bool deleteTopics,
            bool deletePosts)
        {
            Id = id;
            EntityId = entityId;
            EntityType = entityType;
            ForumId = forumId;
            CreateTopics = createTopics;
            CreatePosts = createPosts;
            Read = read;
            EditPosts = editPosts;
            DeleteTopics = deleteTopics;
            DeletePosts = deletePosts;
        }
    }
}
