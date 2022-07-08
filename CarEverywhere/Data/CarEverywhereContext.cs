using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarEverywhere.Models;

namespace CarEverywhere.Data
{
    public class CarEverywhereContext : DbContext
    {
        public CarEverywhereContext (DbContextOptions<CarEverywhereContext> options)
            : base(options)
        {
        }

        public DbSet<CarEverywhere.Models.Car>? Car { get; set; }

        public DbSet<CarEverywhere.Models.Client>? Client { get; set; }

        public DbSet<CarEverywhere.Models.Rent>? Rent { get; set; }
    }
}
