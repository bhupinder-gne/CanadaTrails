﻿using Microsoft.AspNetCore.Mvc;
using CanadaTrails.Models.DTO;
using CanadaTrails.API.Data;
using CanadaTrails.Repository;
using CanadaTrails.Models.Domain;
using AutoMapper;

namespace CanadaTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        //Create Walk
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateWalkAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
        
        //GET ALL WALKS
        //GET api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walks = await walkRepository.GetWalksAsync();
            return Ok(mapper.Map<List<WalkDto>>(walks));
        }

        //GET WALK BY ID
        //GET api/walks/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walk = await walkRepository.GetWalkAsync(id);
            if (walk == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(walk));
        }

        //Update Walk
        //PUT api/walks/{id}
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk(Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walk = mapper.Map<Walk>(updateWalkRequestDto);
            var updatedWalk = await walkRepository.UpdateWalkAsync(id, walk);
            if (updatedWalk == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(updatedWalk));
        }

        //Delete Walk
        //DELETE api/walks/{id}
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var walk = await walkRepository.DeleteWalkAsync(id);
            if (walk == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(walk));
        }
    }
}