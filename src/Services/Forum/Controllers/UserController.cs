using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IForumRepository _forumRepository;

        public UserController(
            ILogger<UserController> logger,
            IForumRepository forumRepository
        )
        {
            _logger = logger;
            _forumRepository = forumRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] UserDtoIn userDtoIn)
        {
            var userDtoOut = await _forumRepository.AddUserAsync(userDtoIn);

            return Created(string.Empty, userDtoOut);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var userDtoOut = await _forumRepository.GetUserByIdAsync(id);

            if (userDtoOut == null)
                return NotFound($"Пользователь с ID {id} не найден");

            return Ok(userDtoOut);
        }

        [HttpGet("ByLogin/{login}")]
        public async Task<IActionResult> GetByLogin(string login)
        {
            var userDtoOut = await _forumRepository.GetUserByLoginAsync(login);

            if (userDtoOut == null)
                return NotFound($"Пользователь с логином {login} не найден");

            return Ok(userDtoOut);
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> Filterby([FromBody] UserFilterDtoIn filter)
        {
            var filteredUsers = await _forumRepository.GetUsersByFilterAsync(filter);

            if(filteredUsers == null)
                return NotFound("Пользователи не найдены");

            return Ok(filteredUsers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] UserDtoIn userDtoIn)
        {
            var existedUser = await _forumRepository.GetUserByIdAsync(id);

            if (existedUser == null)
                return NotFound($"Пользователь с ID {id} не найден");
            
            var userDtoOut = UserDtoInConverter.ToDtoOut(
                source: userDtoIn,
                id: id
            );

            var updatedUserDtoOut = await _forumRepository.UpdateUserAsync(userDtoOut);

            return Ok(updatedUserDtoOut);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existedUser = await _forumRepository.GetUserByIdAsync(id);

            if (existedUser == null)
                return NotFound($"Пользователь с ID {id} не найден");

            await _forumRepository.DeleteUserAsync(id);

            return Ok();
        }
    }
}
