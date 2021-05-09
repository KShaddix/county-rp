﻿using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;
using CountyRP.Services.Forum.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Создать пользователя.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] UserDtoIn userDtoIn)
        {
            if (userDtoIn.Login == null || userDtoIn.Login.Length < 3 || userDtoIn.Login.Length > 32)
            {
                return BadRequest(ConstantMessages.UserInvalidLoginLength);
            }
            if (!Regex.IsMatch(userDtoIn.Login, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
            {
                return BadRequest(ConstantMessages.UserInvalidLogin);
            }
            if (userDtoIn.GroupId == null || userDtoIn.GroupId.Length < 3 || userDtoIn.GroupId.Length > 16)
            {
                return BadRequest(ConstantMessages.UserInvalidGroupIdLength);
            }

            var existedUser = await _forumRepository.GetUserByLoginAsync(userDtoIn.Login);

            if (existedUser != null)
            {
                return BadRequest(ConstantMessages.UserAlreadyExistedWithLogin);
            }

            var userDtoOut = await _forumRepository.AddUserAsync(userDtoIn);

            return Created(
                string.Empty, 
                UserDtoOutConverter.ToApi(userDtoOut)
            );
        }

        /// <summary>
        /// Получить данные пользователя по ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var userDtoOut = await _forumRepository.GetUserByIdAsync(id);

            if (userDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundById, id)
                );
            }

            return Ok(
                UserDtoOutConverter.ToApi(userDtoOut)
            ); 
        }

        /// <summary>
        /// Получить данные пользователя по логину.
        /// </summary>
        [HttpGet("ByLogin/{login}")]
        public async Task<IActionResult> GetByLogin(string login)
        {
            var userDtoOut = await _forumRepository.GetUserByLoginAsync(login);

            if (userDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundByLogin, login)
                );
            }

            return Ok(
                UserDtoOutConverter.ToApi(userDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список пользователей.
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(PagedFilterResult<UserDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Filterby([FromQuery] ApiUserFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.InvalidCountItemPerPage);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiUserFilterDtoInConverter.ToRepository(filter);

            var filteredUsers = await _forumRepository.GetUsersByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredUsers)
            );
        }

        /// <summary>
        /// Изменить данные пользователя по ID.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] UserDtoIn userDtoIn)
        {
            var existedUser = await _forumRepository.GetUserByIdAsync(id);

            if (existedUser == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundById, id)
                );
            }

            if (userDtoIn.Login == null || userDtoIn.Login.Length < 3 || userDtoIn.Login.Length > 32)
            {
                return BadRequest(ConstantMessages.UserInvalidLoginLength);
            }
            if (!Regex.IsMatch(userDtoIn.Login, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
            {
                return BadRequest(ConstantMessages.UserInvalidLogin);
            }
            if (userDtoIn.GroupId == null || userDtoIn.GroupId.Length < 3 || userDtoIn.GroupId.Length > 16)
            {
                return BadRequest(ConstantMessages.UserInvalidGroupIdLength);
            }

            var existedUserWithLogin = await _forumRepository.GetUserByLoginAsync(userDtoIn.Login);

            if (existedUserWithLogin != null && existedUser.Id != existedUserWithLogin.Id)
            {
                return BadRequest(ConstantMessages.UserAlreadyExistedWithLogin);
            }

            var userDtoOut = UserDtoInConverter.ToDtoOut(
                source: userDtoIn,
                id: id
            );

            var updatedUserDtoOut = await _forumRepository.UpdateUserAsync(id, userDtoOut);

            return Ok(
                UserDtoOutConverter.ToApi(updatedUserDtoOut)
            );
        }

        /// <summary>
        /// Удалить пользователя по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedUser = await _forumRepository.GetUserByIdAsync(id);

            if (existedUser == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundById, id)
                );
            }

            await _forumRepository.DeleteUserAsync(id);

            return Ok();
        }
    }
}
