﻿using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial class ForumRepository
    {
        public async Task<ForumDtoOut> CreateForumAsync(ForumDtoIn forumDtoIn)
        {
            var forumDao = ForumDtoInConverter.ToDb(forumDtoIn);

            await _forumDbContext.Forums.AddAsync(forumDao);
            await _forumDbContext.SaveChangesAsync();

            return ForumDaoConverter.ToRepository(forumDao);
        }

        public async Task<IEnumerable<ForumDtoOut>> GetForumsAsync()
        {
            var forumsDao = await _forumDbContext
                .Forums
                .AsNoTracking()
                .ToArrayAsync();

            var forumsDto = new List<ForumDtoOut>();

            foreach (var forum in forumsDao)
            {
                forumsDto.Add(ForumDaoConverter.ToRepository(forum));
            }

            return forumsDto ?? null;
        }

        public async Task<ForumDtoOut> GetForumByIdAsync(int id)
        {
            var forumDao = await _forumDbContext
                .Forums
                .AsNoTracking()
                .FirstOrDefaultAsync(forums => forums.Id == id);

            return (forumDao != null)
                ? ForumDaoConverter.ToRepository(forumDao)
                : null;
        }

        public async Task<PagedFilterResult<ForumDtoOut>> GetForumsByFilterAsync(ForumFilterDtoIn filter)
        {
            var forumsQuery = _forumDbContext
                .Forums
                .Where(
                    forum => forum.ParentId.Equals(filter.ParentId)
                )
                .AsQueryable();

            var allCount = await forumsQuery.CountAsync();
            var maxPages = (allCount % filter.Count == 0)
                ? allCount / filter.Count
                : allCount / filter.Count + 1;

            var filteredForumsDao = await forumsQuery
                .Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count)
                .ToListAsync();

            return new PagedFilterResult<ForumDtoOut>(
                allCount: allCount,
                page: filter.Page,
                maxPages: maxPages,
                items: filteredForumsDao
                    .Select(ForumDaoConverter.ToRepository)
            );
        }

        public async Task<ForumDtoOut> UpdateForumAsync(ForumDtoOut forum)
        {
            var forumDao = ForumDtoOutConverter.ToDb(forum);

            var updatedForumDao = _forumDbContext.Forums.Update(forumDao)?.Entity;
            await _forumDbContext.SaveChangesAsync();

            return (updatedForumDao != null)
                ? ForumDaoConverter.ToRepository(updatedForumDao)
                : null;
        }

        public async Task DeleteForumAsync(int id)
        {
            var forum = await _forumDbContext
                .Forums
                .FirstAsync(f => f.Id.Equals(id));

            _forumDbContext.Forums.Remove(forum);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
