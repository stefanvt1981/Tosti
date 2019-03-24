using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TostiBackEnd.Entity;
using TostiBusinessEntities;

namespace TostiBackEnd.Context
{
    public class TostiDBContext : DbContext
    {
        public DbSet<TostiEntity> Tostis { get; set; }

        public TostiDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TostiEntity>().HasData(new TostiEntity
            {
                Id = 1,
                Brood = "Witbrood",
                Calorieen = 400,
                Naam = "HamKaas",
                Vulling = "Ham en Kaas"
            });
        }
    }
}
