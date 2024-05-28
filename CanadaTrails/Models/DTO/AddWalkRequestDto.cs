using System.ComponentModel.DataAnnotations;

namespace CanadaTrails.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of length 100")]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Description has to be maximum of length 500")]
        public string Description { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Length has to be between 0 and 1000")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
