using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite.Model
{
    public class FavouriteMgmtDBContext : DbContext
    {
        public FavouriteMgmtDBContext(DbContextOptions<FavouriteMgmtDBContext> dbContextOptions) : base(dbContextOptions)
        {
           // Database.EnsureCreated();
        }

        public DbSet<FavouriteList> FavouritData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
}
}
