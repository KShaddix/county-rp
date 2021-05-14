namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiForumDtoIn
    {
        public string Name { get; }

        public int ParentId { get; }

        public int Order { get; }

        public ApiForumDtoIn(
            string name,
            int parentId,
            int order
        )
        {
            Name = name;
            ParentId = parentId;
            Order = order;
        }
    }
}
