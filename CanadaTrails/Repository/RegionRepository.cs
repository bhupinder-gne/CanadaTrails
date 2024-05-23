using Microsoft.EntityFrameworkCore;
using CanadaTrails.Models.Domain;
using CanadaTrails.API.Data;

namespace CanadaTrails.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly CanadaTrailsDbContext _context;
        public RegionRepository(CanadaTrailsDbContext context) { 
            _context = context;
        }

        public Task<Region> CreateRegionAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region> DeleteRegionAsync(Guid regionId)
        {
            throw new NotImplementedException();
        }

        public Task<Region> GetRegionAsync(Guid regionId)
        {
            throw new NotImplementedException();
        }

        public Task<Region> UpdateRegionAsync(Guid regionId, Region region)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetRegionsAsync()
        {
            return await _context.Regions.ToListAsync();
        }
    }
}
