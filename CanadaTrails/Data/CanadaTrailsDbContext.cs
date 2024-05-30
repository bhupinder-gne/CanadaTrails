using CanadaTrails.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CanadaTrails.API.Data
{
    public class CanadaTrailsDbContext : DbContext
    {
        public CanadaTrailsDbContext(DbContextOptions<CanadaTrailsDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.NewGuid(),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Walker",
                    Code = "WLK",
                    RegionImageUrl = "walker.jpg"
                },
                 new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Summer Side",
                    Code = "SMS",
                    RegionImageUrl = "summerSide.jpg"
                },
                  new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Aurora",
                    Code = "AUR",
                    RegionImageUrl = "aurora.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
