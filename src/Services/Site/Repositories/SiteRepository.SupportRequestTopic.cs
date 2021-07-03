﻿using CountyRP.Services.Site.Converters;
using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Repositories
{
    public partial class SiteRepository
    {
        public async Task<SupportRequestTopicDtoOut> AddSupportRequestTopicAsync(SupportRequestTopicDtoIn supportRequestTopicDtoIn)
        {
            var supportRequestTopicDao = SupportRequestTopicDtoInConverter.ToDb(
                source: supportRequestTopicDtoIn
            );

            _siteDbContext.SupportRequestTopics.Add(supportRequestTopicDao);
            await _siteDbContext.SaveChangesAsync();

            return SupportRequestTopicDaoConverter.ToRepository(
                source: supportRequestTopicDao
            );
        }

        public async Task<SupportRequestTopicDtoOut> GetSupportRequestTopicAsync(int id)
        {
            var supportRequestTopic = await _siteDbContext
                .SupportRequestTopics
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    supportRequestTopic => supportRequestTopic.Id == id
                );

            return SupportRequestTopicDaoConverter.ToRepository(
                source: supportRequestTopic
            );
        }

        public async Task<PagedFilterResult<SupportRequestTopicDtoOut>> GetSupportRequestTopicsByFilterAsync(SupportRequestTopicFilterDtoIn filter)
        {
            SupportRequestTopicTypeDao? supportRequestTopicType =
                filter.Type.HasValue
                ? SupportRequestTopicTypeDtoConverter.ToDb(filter.Type.Value)
                : null;

            SupportRequestTopicStatusDao? supportRequestTopicStatus =
                filter.Status.HasValue
                ? SupportRequestTopicStatusDtoConverter.ToDb(filter.Status.Value)
                : null;

            var supportRequestTopicQuery = _siteDbContext
                .SupportRequestTopics
                .AsNoTracking()
                .Where(
                    supportRequestTopic =>
                        (!supportRequestTopicType.HasValue || supportRequestTopic.Type == supportRequestTopicType.Value) &&
                        (!supportRequestTopicStatus.HasValue || supportRequestTopic.Status == supportRequestTopicStatus.Value) &&
                        (!filter.CreatorUserId.HasValue || supportRequestTopic.CreatorUserId == filter.CreatorUserId) &&
                        (!filter.RefUserId.HasValue || supportRequestTopic.RefUserId == filter.RefUserId)
                );

            var allCount = await supportRequestTopicQuery.CountAsync();
            var maxPages = allCount / filter.Count;

            var filteredSupportRequestTopicsDao = await supportRequestTopicQuery
                .OrderBy(supportRequestTopic => supportRequestTopic.Id)
                .Skip((filter.Page - 1) * filter.Count)
                .Take(filter.Count)
                .ToListAsync();

            return new PagedFilterResult<SupportRequestTopicDtoOut>(
                allCount: allCount,
                page: filter.Page,
                maxPages: maxPages,
                items: filteredSupportRequestTopicsDao
                    .Select(SupportRequestTopicDaoConverter.ToRepository)
            );
        }

        public async Task<PagedFilterResult<SupportRequestTopicWithFirstAndLastMessagesDtoOut>> GetSupportRequestTopicsByFilterByFirstMessagesAsync(
            SupportRequestTopicFilterDtoIn filter
        )
        {
            SupportRequestTopicTypeDao? supportRequestTopicType =
                filter.Type.HasValue
                ? SupportRequestTopicTypeDtoConverter.ToDb(filter.Type.Value)
                : null;

            SupportRequestTopicStatusDao? supportRequestTopicStatus =
                filter.Status.HasValue
                ? SupportRequestTopicStatusDtoConverter.ToDb(filter.Status.Value)
                : null;

            var supportRequestTopicByFirstMessagesQuery = _siteDbContext
                .SupportRequestMessages
                .AsNoTracking()
                .Select(supportRequestMessage => supportRequestMessage.TopicId).Distinct()
                .Select(key => _siteDbContext
                    .SupportRequestMessages
                    .AsNoTracking()
                    .Where(supportRequestMessage => supportRequestMessage.TopicId == key)
                    .OrderByDescending(supportRequestMessage => supportRequestMessage.CreationDate)
                    .First()
                )
                .OrderByDescending(supportRequestMessage => supportRequestMessage.CreationDate)
                .Join(
                    _siteDbContext.SupportRequestTopics,
                    supportRequestMessage => supportRequestMessage.TopicId,
                    supportRequestTopic => supportRequestTopic.Id,
                    (supportRequestMessage, supportRequestTopic) => new SupportRequestTopicWithFirstAndLastMessagesDao
                    {
                        Topic = supportRequestTopic,
                        FirstMessage = _siteDbContext
                            .SupportRequestMessages
                            .AsNoTracking()
                            .Where(supportRequestFirstMessage => supportRequestFirstMessage.TopicId == supportRequestMessage.TopicId)
                            .OrderBy(supportRequestFirstMessage => supportRequestFirstMessage.CreationDate)
                            .First(),
                        LastMessage = supportRequestMessage
                    }
                )
                .Where(
                    supportRequestTopic =>
                        (!supportRequestTopicType.HasValue || supportRequestTopic.Topic.Type == supportRequestTopicType.Value) &&
                        (!supportRequestTopicStatus.HasValue || supportRequestTopic.Topic.Status == supportRequestTopicStatus.Value) &&
                        (!filter.CreatorUserId.HasValue || supportRequestTopic.Topic.CreatorUserId == filter.CreatorUserId) &&
                        (!filter.RefUserId.HasValue || supportRequestTopic.Topic.RefUserId == filter.RefUserId)
                    );

            var allCount = await supportRequestTopicByFirstMessagesQuery.CountAsync();
            var maxPages = allCount / filter.Count;

            var filteredSupportRequestTopicsWithMessageDao = await supportRequestTopicByFirstMessagesQuery
                .Skip((filter.Page - 1) * filter.Count)
                .Take(filter.Count)
                .ToListAsync();

            return new PagedFilterResult<SupportRequestTopicWithFirstAndLastMessagesDtoOut>(
                allCount: allCount,
                page: filter.Page,
                maxPages: maxPages,
                items: filteredSupportRequestTopicsWithMessageDao
                    .Select(SupportRequestTopicWithMessageDaoConverter.ToRepository)
            );
        }

        public async Task<SupportRequestTopicDtoOut> UpdateSupportRequestTopicAsync(SupportRequestTopicDtoOut supportRequestTopicDtoOut)
        {
            var supportRequestTopicDao = SupportRequestTopicDtoOutConverter.ToDb(
                source: supportRequestTopicDtoOut
            );

            supportRequestTopicDao = _siteDbContext
                .SupportRequestTopics
                .Update(supportRequestTopicDao)
                ?.Entity;
            await _siteDbContext.SaveChangesAsync();

            return SupportRequestTopicDaoConverter.ToRepository(
                source: supportRequestTopicDao
            );
        }

        public async Task DeleteSupportRequestTopicAsync(int id)
        {
            var supportRequestTopic = await _siteDbContext
                .SupportRequestTopics
                .FirstOrDefaultAsync(
                    supportRequestTopic => supportRequestTopic.Id == id
                );

            _siteDbContext.SupportRequestTopics.Remove(supportRequestTopic);
            await _siteDbContext.SaveChangesAsync();
        }
    }
}
