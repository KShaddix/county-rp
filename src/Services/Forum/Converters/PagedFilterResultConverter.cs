﻿using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;
using System.Linq;

namespace CountyRP.Services.Forum.Converters
{
    internal static class PagedFilterResultConverter
    {
        public static ApiPagedFilterResult<ApiUserDtoOut> ToApi(
            PagedFilterResult<UserDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiUserDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(UserDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResult<ApiForumDtoOut> ToApi(
            PagedFilterResult<ForumDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiForumDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(ForumDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResult<ApiTopicDtoOut> ToApi(
            PagedFilterResult<TopicDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiTopicDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(UserDtoOutConverter.ToApi)
            );
        }
    }
}
