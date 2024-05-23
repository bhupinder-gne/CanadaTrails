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

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid regionId)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(r => r.Id == regionId);
            if (existingRegion == null)
                return null;

            _context.Regions.Remove(existingRegion);
            await _context.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region?> GetRegionAsync(Guid regionId)
        {
            return await _context.Regions.FindAsync(regionId);
        }

        public async Task<Region?> UpdateRegionAsync(Guid regionId, Region region)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(r => r.Id == regionId);
            if(existingRegion == null)
                return null;

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _context.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetRegionsAsync()
        {
            return await _context.Regions.ToListAsync();
        }
    }
}
