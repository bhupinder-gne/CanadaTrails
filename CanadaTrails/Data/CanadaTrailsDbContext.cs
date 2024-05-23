using CanadaTrails.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CanadaTrails.API.Data
{
    public class CanadaTrailsDbContext : DbContext
    {
        public CanadaTrailsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
