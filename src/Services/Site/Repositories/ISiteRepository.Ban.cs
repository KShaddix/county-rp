﻿using CountyRP.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Repositories
{
    public partial interface ISiteRepository
    {
        Task<BanDtoOut> AddBanAsync(BanDtoIn banDtoIn);

        Task<BanDtoOut> GetBanAsync(int id);

        Task<PagedFilterResult<BanDtoOut>> GetBansByFilterAsync(BanFilterDtoIn filter);

        Task<BanDtoOut> UpdateBanAsync(BanDtoOut banDtoOut);

        Task DeleteBanAsync(int id);
    }
}