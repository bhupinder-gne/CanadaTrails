using Microsoft.AspNetCore.Mvc;
using CanadaTrails.Models.DTO;
using CanadaTrails.API.Data;
using CanadaTrails.Repository;
using CanadaTrails.Models.Domain;

namespace CanadaTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;

        public RegionsController(CanadaTrailsDbContext context, IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        //GET ALL REGIONS
        //GET api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetRegionsAsync();
            //Map the regions to RegionDto
            var regionsDto = regions.Select(region => new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            }).ToList();

            return Ok(regionsDto);
        }

        //GET REGION BY ID
        //GET api/regions/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await regionRepository.GetRegionAsync(id);
            if (region == null)
                return NotFound();

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }

        //Create New Region
        //POST api/regions
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] UpsertRegionDto regionDto)
        {
            if (regionDto == null)
                return BadRequest();

            var region = new Region
            {
                Id = Guid.NewGuid(),
                Code = regionDto.Code,
                Name = regionDto.Name,
                RegionImageUrl = regionDto.RegionImageUrl
            };

           await regionRepository.CreateRegionAsync(region);

            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, region);
        }

        //Update Region
        //PUT api/regions/{id}
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id, [FromBody] UpsertRegionDto regionDto)
        {
            var region = await regionRepository.GetRegionAsync(id);
            if (region == null)
                return NotFound();

            return NoContent();
        }

        //Delete Region
        //DELETE api/regions/{id}
        [HttpDelete("{id:Guid}")]
        public async  Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await regionRepository.GetRegionAsync(id);
            if (region == null)
                return NotFound();

            return NoContent();
        }
        
    }
}
