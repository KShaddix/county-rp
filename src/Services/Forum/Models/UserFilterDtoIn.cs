namespace CountyRP.Services.Forum.Models
{
    public class UserFilterDtoIn : PagedFilter
    {
        public string Login { get; }
        public string GroupId { get; }
        public string SortingFlag{ get; }

        public UserFilterDtoIn(
            int count,
            int page,
            string login,
            string groupId,
            string sortingFlag
            )
            : base (count, page)
        {
            Login = login;
            GroupId = groupId;
            SortingFlag = sortingFlag;
        }
    }
}
