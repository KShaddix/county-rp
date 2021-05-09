﻿using System.Collections.Generic;

namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiUserFilterDtoIn : ApiPagedFilter
    {
        public string Login { get; set; }

        public string SortingFlag { get; }

        public IEnumerable<string> GroupIds { get; set; }
    }
}