﻿using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<HouseDtoOut> AddHouseAsync(HouseDtoIn houseDtoIn);

        public Task<PagedFilterResultDtoOut<HouseDtoOut>> GetHousesByFilter(HouseFilterDtoIn filter);

        public Task<HouseDtoOut> UpdateHouseAsync(HouseDtoOut houseDtoOut);

        public Task DeleteHouseByFilter(HouseFilterDtoIn filter);
    }
}
