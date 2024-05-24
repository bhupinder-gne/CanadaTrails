using AutoMapper;
using CanadaTrails.Models.Domain;
using CanadaTrails.Models.DTO;

namespace CanadaTrails.Mappings
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, UpsertRegionDto>().ReverseMap();
            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, UpdateWalkRequestDto>().ReverseMap();
        }
    }
}
