using CanadaTrails.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CanadaTrails.API.Data
{
    public class CanadaTrailsAuthDbContext : IdentityDbContext
    {
        public CanadaTrailsAuthDbContext(DbContextOptions<CanadaTrailsAuthDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var readerId = "9adb8175-5674-466a-9879-244ceba5b3d5";
            var writerId = "5c855fdb-7ba5-47f9-817c-c9113ffcb29b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id = readerId, ConcurrencyStamp=readerId, Name = "Reader", NormalizedName = "READER" },
                new IdentityRole { Id = writerId, ConcurrencyStamp=writerId, Name = "Writer", NormalizedName = "WRITER" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
