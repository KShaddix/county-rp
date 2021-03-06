﻿using CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Exceptions;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game
{
    public partial class GameService
    {
        public async Task<GamePlayerDtoOut> GetPlayerByIdAsync(int id)
        {
            try
            {
                var gameApiPlayerDtoOut = await _playerClient.GetByIdAsync(id);

                return GameApiPlayerDtoOutConverter.ToService(
                    source: gameApiPlayerDtoOut
                );
            }
            catch (ApiException<ApiErrorResponseDtoOut> ex)
            {
                throw new ServiceException<ServiceErrorResponseDtoOut>(
                    message: ex.Message,
                    statusCode: ex.StatusCode,
                    result: ApiErrorResponseDtoOutConverter.ToService(ex.Result)
                );
            }
            catch (ApiException ex)
            {
                throw new ServiceException(
                    message: ex.Message,
                    statusCode: ex.StatusCode
                );
            }
        }

        public async Task<GamePagedFilterResultDtoOut<GamePlayerDtoOut>> GetPlayersByFilter(
            GamePlayerFilterDtoIn gameFilterPlayerDtoIn
        )
        {
            try
            {
                var gameApiPagedPlayersDtoOut = await _playerClient.FilterByAsync(
                    ids: gameFilterPlayerDtoIn.Ids,
                    logins: gameFilterPlayerDtoIn.Logins,
                    startRegistrationDate: gameFilterPlayerDtoIn.StartRegistrationDate,
                    finishRegistrationDate: gameFilterPlayerDtoIn.FinishRegistrationDate,
                    startLastVisitDate: gameFilterPlayerDtoIn.StartLastVisitDate,
                    finishLastVisitDate: gameFilterPlayerDtoIn.FinishRegistrationDate,
                    count: gameFilterPlayerDtoIn.Count,
                    page: gameFilterPlayerDtoIn.Page
                );

                return GameApiPagedFilterResultDtoOutConverter.ToService(
                    gameApiPagedPlayersDtoOut
                );
            }
            catch (ApiException<ApiErrorResponseDtoOut> ex)
            {
                throw new ServiceException<ServiceErrorResponseDtoOut>(
                    message: ex.Message,
                    statusCode: ex.StatusCode,
                    result: ApiErrorResponseDtoOutConverter.ToService(ex.Result)
                );
            }
            catch (ApiException ex)
            {
                throw new ServiceException(
                    message: ex.Message,
                    statusCode: ex.StatusCode
                );
            }
        }
    }
}
