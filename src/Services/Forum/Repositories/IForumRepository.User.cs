using CountyRP.Services.Forum.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial interface IForumRepository
    {
        Task<UserDtoOut> AddUserAsync(UserDtoIn user);
        Task<UserDtoOut> GetUserByIdAsync(int id);
        Task<UserDtoOut> GetUserByLoginAsync(string login);
        Task<PagedFilterResult<UserDtoOut>> GetUsersByFilterAsync(UserFilterDtoIn filter);
        Task<UserDtoOut> UpdateUserAsync(UserDtoOut userDtoOut);
        Task DeleteUserAsync(int id);
    }
}
