using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PeopleApp.Core.Dto;
using PeopleApp.Infrastructure.Services.Region.Models;

namespace PeopleApp.Infrastructure.Services.Region
{
    public class RegionService : IRegionService
    {
        public readonly Guid RussiaId = Guid.Parse("583539AA-A28D-47DE-907A-2EA9B0BE7B73");

        private readonly IUnitOfWork _uow;

        public RegionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<RegionTypeVm> GetRegions()
        {
            var allRegions = new List<RegionTypeVm>();

            allRegions.Add(new RegionTypeVm(RussiaId, "Россия", RegionType.Russia));

            var okrugs = Mapper.Map<IEnumerable<OkrugDto>>(_uow.Okrugs.GetAll(false));
            allRegions.AddRange(okrugs.Select(o => new RegionTypeVm(o.Id, o.Name, RegionType.Okrug)));

            var regions = Mapper.Map<IEnumerable<RegionDto>>(_uow.Regions.GetAll(false));
            allRegions.AddRange(regions.Select(r => new RegionTypeVm(r.Id, r.Name, RegionType.Region)));

            return allRegions;
        }
    }
}