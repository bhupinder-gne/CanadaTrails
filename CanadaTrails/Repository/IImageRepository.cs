using CanadaTrails.Models.Domain;

namespace CanadaTrails.Repository
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
