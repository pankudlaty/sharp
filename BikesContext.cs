using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace sharp {

        public class BikeContext : DbContext {
                public DbSet<Bike> Bikes {get; set;}
                
                public string DbPath{get;}

                public BikeContext() {
                        DbPath = "bikes.db";
                }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite($"Data Source={DbPath}");
    }


}