using CanadaTrails.API.Data;
using CanadaTrails.Models.Domain;

namespace CanadaTrails.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly CanadaTrailsDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, CanadaTrailsDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "images", $"{ image.FileName}{image.FileExtension}");

            //Upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlFile = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFile;

            //Save image to database
            await context.Images.AddAsync(image);
            await context.SaveChangesAsync();
            return image;
        }
    }
}
