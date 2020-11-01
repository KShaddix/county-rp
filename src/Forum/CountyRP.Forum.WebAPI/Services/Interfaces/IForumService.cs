using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface IForumService
    {
        Task<IEnumerable<ForumInfoViewModel>> GetForumsInfo();
    }
}
