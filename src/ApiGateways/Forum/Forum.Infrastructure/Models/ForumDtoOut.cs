﻿namespace CountyRP.ApiGateways.Forum.Infrastructure.Models
{
    public class ForumDtoOut
    {
        public int Id { get; set; }

        public string Name { get; }

        public int ParentId { get; }

        public int Order { get; }

        public ForumDtoOut(
            int id,
            string name,
            int parentId,
            int order
        )
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Order = order;
        }
    }
}
