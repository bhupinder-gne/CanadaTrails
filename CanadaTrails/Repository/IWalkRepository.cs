using CanadaTrails.Models.Domain;

namespace CanadaTrails.Repository
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<List<Walk>> GetWalksAsync(string? filterOn = null, string? filterQuery = null);
        Task<Walk?> GetWalkAsync(Guid walkId);
        Task<Walk?> UpdateWalkAsync(Guid walkId, Walk walk);
        Task<Walk?> DeleteWalkAsync(Guid walkId);
    }
}
