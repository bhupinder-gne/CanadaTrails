using CanadaTrails.Models.Domain;

namespace CanadaTrails.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetRegionsAsync();
        //Task<Region> GetRegionAsync(Guid regionId);
        //Task<Region> CreateRegionAsync(Region region);
        //Task<Region> UpdateRegionAsync(Guid regionId, Region region);
        //Task<Region> DeleteRegionAsync(Guid regionId);
    }
}
