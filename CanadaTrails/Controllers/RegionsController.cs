using Microsoft.AspNetCore.Mvc;
using CanadaTrails.Models.DTO;
using CanadaTrails.API.Data;
using CanadaTrails.Repository;
using CanadaTrails.Models.Domain;
using AutoMapper;
using CanadaTrails.CustomActionFilter;
using Microsoft.AspNetCore.Authorization;

namespace CanadaTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private CanadaTrailsDbContext _context;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(CanadaTrailsDbContext context, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this._context = context;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        //GET ALL REGIONS 
        //GET api/regions
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                throw new Exception("Test Exception");
                var regions = await regionRepository.GetRegionsAsync();
                return Ok(mapper.Map<List<RegionDto>>(regions));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting all regions");
                return StatusCode(500, "Internal Server Error");

            }
        }

        //GET REGION BY ID
        //GET api/regions/{id}
        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await regionRepository.GetRegionAsync(id);
            if (region == null)
                return NotFound();

            return Ok(mapper.Map<RegionDto>(region));
        }

        //Create New Region
        //POST api/regions
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegion([FromBody] UpsertRegionDto regionDto)
        {
            if (regionDto == null)
                return BadRequest();

            var region = mapper.Map<Region>(regionDto);

            await regionRepository.CreateRegionAsync(region);

            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, region);
        }

        //Update Region
        //PUT api/regions/{id}
        [HttpPut("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion(Guid id, [FromBody] UpsertRegionDto regionDto)
        {
            var updatedRegion = mapper.Map<Region>(regionDto);
            var region = await regionRepository.UpdateRegionAsync(id, updatedRegion);
            if (region == null)
                return NotFound();

            return Ok(region);
        }

        //Delete Region
        //DELETE api/regions/{id}
        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Writer,Reader")]
        public async  Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteRegionAsync(id);
            if (region == null)
                return NotFound();

            return NoContent();
        }
        
    }
}
