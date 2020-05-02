﻿using Microsoft.EntityFrameworkCore;

using CountyRP.Entities;

namespace CountyRP.WebAPI.Models
{
    public class GangContext : DbContext
    {
        public DbSet<Gang> Gangs { get; set; }

        public GangContext(DbContextOptions<GangContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}