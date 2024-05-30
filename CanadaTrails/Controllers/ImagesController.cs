using CanadaTrails.Models.Domain;
using CanadaTrails.Models.DTO;
using CanadaTrails.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanadaTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        // POST api/images/upload
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = new Image
            {
                File = request.File,
                FileName = request.FileName,
                FileDescription = request.FileDescription,
                FileExtension = Path.GetExtension(request.File.FileName),
                FileSizeInBytes = request.File.Length
            };

            //Save image to file system
            await imageRepository.Upload(image);

            return Ok(image);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            //Allowed file extensions
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            if(!allowedExtensions.Contains(Path.GetExtension(request.File.FileName).ToLowerInvariant()))
                ModelState.AddModelError("File", "Invalid file extension");

            //Size of file in bytes
            if(request.File.Length > 10485760)
                ModelState.AddModelError("File", "File size exceeds 10MB");
        }
    }
}
