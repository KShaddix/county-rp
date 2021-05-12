﻿using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    internal static class ApiUpdateGroupDtoInConverter
    {
        public static GroupDtoOut ToDtoOut(
           ApiUpdateGroupDtoIn source,
           string id
        )
        {
            return new GroupDtoOut(
                id: id,
                name: source.Name,
                color: source.Color,
                admin: source.Admin,
                adminPanel: source.AdminPanel,
                createUsers: source.CreateUsers,
                deleteUsers: source.DeleteUsers,
                changeLogin: source.ChangeLogin,
                changeGroup: source.ChangeGroup,
                editGroups: source.EditGroups,
                maxBan: source.MaxBan,
                banGroupIds: source.BanGroupIds,
                seeLogs: source.SeeLogs
            );
        }
    }
}
