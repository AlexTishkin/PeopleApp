using System;
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
            CreateMap<BirthRate, BirthRateDto>().ReverseMap();
            CreateMap<DeathRate, DeathRateDto>().ReverseMap();
            CreateMap<CensusPlace, CensusPlaceDto>().ReverseMap();
        }
    }
}