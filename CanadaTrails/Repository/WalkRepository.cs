﻿using CanadaTrails.API.Data;
using CanadaTrails.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CanadaTrails.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly CanadaTrailsDbContext context;
        public WalkRepository(CanadaTrailsDbContext context)
        {
            this.context = context;
        }


        public async  Task<Walk> CreateWalkAsync(Walk walk)
        {
           await context.Walks.AddAsync(walk);
           await context.SaveChangesAsync();
           return walk;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid walkId)
        {
            var walk = await context.Walks.FirstOrDefaultAsync(w => w.Id == walkId);
            if (walk == null)
                return null;
            context.Walks.Remove(walk);
            await context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> GetWalkAsync(Guid walkId)
        {
            var walk = await context.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(w => w.Id == walkId);
            if(walk == null)
                return null;
            return walk;
        }

        public async Task<List<Walk>> GetWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool? isAscending = true, int? page = 1, int? pageSize = 10)
        {
            var walks = context.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //Filtering
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery) && (filterOn.Equals("Name", StringComparison.Ordinal) || filterOn.Equals("Description", StringComparison.Ordinal)))
                walks = walks.Where(w => EF.Property<string>(w, filterOn).Contains(filterQuery));

            //Sorting
            if (!string.IsNullOrEmpty(sortBy) && (sortBy.Equals("Name", StringComparison.Ordinal) || sortBy.Equals("Description", StringComparison.Ordinal)))
            {
                walks = isAscending.Value ? walks.OrderBy(w => EF.Property<string>(w, sortBy)) : walks.OrderByDescending(w => EF.Property<string>(w, sortBy));
            }

            //Pagination
            walks = walks.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return await walks.ToListAsync();
        }

        public async Task<Walk?> UpdateWalkAsync(Guid walkId, Walk walk)
        {
            var existingWalk = await context.Walks.FirstOrDefaultAsync(w => w.Id == walkId);
            if (existingWalk == null)
                return null;

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.Difficulty = walk.Difficulty;
            existingWalk.RegionId = walk.RegionId;

            return walk;
        }
    }
}
