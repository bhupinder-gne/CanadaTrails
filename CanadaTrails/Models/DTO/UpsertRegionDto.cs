using System.ComponentModel.DataAnnotations;

namespace CanadaTrails.Models.DTO
{
    public class UpsertRegionDto
    {
        [Required]
        [MaxLength(3,ErrorMessage ="Code has to be maximum of length 3")]
        [MinLength(3, ErrorMessage = "Code has to be minimum of length 3")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of length 100")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
