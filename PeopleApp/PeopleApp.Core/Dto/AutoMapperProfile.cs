using AutoMapper;
using PeopleApp.Core.Entity;

namespace PeopleApp.Core.Dto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Okrug, OkrugDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
        }
    }
}