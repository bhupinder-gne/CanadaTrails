using CanadaTrails.Models.Domain;

namespace CanadaTrails.Repository
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public Task<List<Region>> GetRegionsAsync()
        {
            return Task.FromResult(new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "AUK",
                    Name = "Auckland",
                    RegionImageUrl = "https://www.doc.govt.nz/global/images/places/auckland/auckland-1.jpg"
                }
            });
        }
    }
}
