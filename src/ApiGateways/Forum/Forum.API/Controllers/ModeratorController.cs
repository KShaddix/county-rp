using CountyRP.ApiGateways.Forum.API.Models;
using CountyRP.ApiGateways.Forum.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModeratorController : ControllerBase
    {
        private readonly IModeratorService _moderatorService;

        public ModeratorController(IModeratorService moderatorService)
        {
            _moderatorService = moderatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApiModeratorDtoIn apiModeratorDtoIn)
        {
            var response = await _moderatorService.Create(
                new Infrastructure.Models.ModeratorDtoIn(
                    apiModeratorDtoIn.EntityId, 
                    apiModeratorDtoIn.EntityType, 
                    apiModeratorDtoIn.ForumId, 
                    apiModeratorDtoIn.CreateTopics, 
                    apiModeratorDtoIn.CreatePosts, 
                    apiModeratorDtoIn.Read, 
                    apiModeratorDtoIn.EditPosts, 
                    apiModeratorDtoIn.DeleteTopics, 
                    apiModeratorDtoIn.DeletePosts)
            );

            return Created(
                string.Empty,
                response);
        }
    }
}
