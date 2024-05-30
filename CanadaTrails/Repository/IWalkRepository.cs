using CanadaTrails.Models.Domain;

namespace CanadaTrails.Repository
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<List<Walk>> GetWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool? isAscending= true, int? page = 1, int? pageSize =10);
        Task<Walk?> GetWalkAsync(Guid walkId);
        Task<Walk?> UpdateWalkAsync(Guid walkId, Walk walk);
        Task<Walk?> DeleteWalkAsync(Guid walkId);
    }
}
