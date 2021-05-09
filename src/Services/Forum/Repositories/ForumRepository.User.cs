﻿using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial class ForumRepository
    {
        public async Task<UserDtoOut> AddUserAsync(UserDtoIn userDtoIn)
        {
            var userDao = UserDtoInConverter.ToDb(userDtoIn);

            await _forumDbContext.Users.AddAsync(userDao);
            await _forumDbContext.SaveChangesAsync();

            return UserDaoConverter.ToRepository(userDao);
        }

        public async Task<UserDtoOut> GetUserByIdAsync(int id)
        {
            var userDao = await _forumDbContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(users => users.Id == id);

            return (userDao != null)
                ? UserDaoConverter.ToRepository(userDao)
                : null;
        }

        public async Task<UserDtoOut> GetUserByLoginAsync(string login)
        {
            var userDao = await _forumDbContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(users => users.Login == login);

            return (userDao != null)
                ? UserDaoConverter.ToRepository(userDao)
                : null;
        }

        public async Task<UserDtoOut> UpdateUserAsync(UserDtoOut userDtoOut)
        {
            var userDao = UserDtoOutConverter.ToDb(userDtoOut);

            var updatedUserDao = _forumDbContext.Users.Update(userDao)?.Entity;
            await _forumDbContext.SaveChangesAsync();

            return (updatedUserDao != null)
                ? UserDaoConverter.ToRepository(updatedUserDao)
                : null;
        }

        public async Task<PagedFilterResult<UserDtoOut>> GetUsersByFilterAsync(UserFilterDtoIn filter)
        {
            var usersQuery = _forumDbContext
                .Users
                .Where(
                    users =>
                        filter.Login != null && users.Login.Contains(filter.Login) &&
                        filter.GroupId != null && filter.GroupId.Contains(users.GroupId)
                )
                .AsQueryable();

            var allCount = await usersQuery.CountAsync();
            var maxPages = allCount / filter.Count;

            var filteredUsersDao = await usersQuery
                .Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count)
                .ToListAsync();

            return new PagedFilterResult<UserDtoOut>(
                allCount: allCount,
                maxPages: maxPages,
                items: filteredUsersDao
                    .Select(UserDaoConverter.ToRepository)
            );
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _forumDbContext
                .Users
                .FindAsync(id);

            _forumDbContext.Users.Remove(user);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
