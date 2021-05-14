namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiForumDtoOut
    {
        public int Id { get; }

        public string Name { get; }

        public int ParentId { get; }

        public int Order { get; }

        public ApiForumDtoOut(
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
