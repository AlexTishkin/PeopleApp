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

        public List<Dictionary<string, int>> GetRegion(Guid id, string[] fields)
        {
            if (fields is null || fields.Length == 0) throw new ArgumentException();

            var region = _uow.Regions.Get(id, true);
            var years = region.BirthRates.Select(b => b.Year).ToList();

            var result = new List<Dictionary<string, int>>();

            foreach(var year in years)
            {
                var item = new Dictionary<string, int>();
                item["year"] = year;

                if (fields.Contains("birth"))
                {
                    var birthCount = region.BirthRates.First(b => b.Year == year).Value;
                    item["birth"] = birthCount;
                }

                if (fields.Contains("death"))
                {
                    var deathCount = region.DeathRates.First(b => b.Year == year).Value;
                    item["death"] = deathCount;
                }

                if (!result.Any(r => r.ContainsValue(year)))
                    result.Add(item);
            }

            return result;
        }

        public IEnumerable<RegionPopulationVm> GetPopulation()
        {
            var regions = _uow.Regions.GetAll().ToList();
            if (!regions.Any()) return new List<RegionPopulationVm>();
            var result = regions.Select(r => new RegionPopulationVm(r.Id, r.Name, r.Population));
            return result;
        }

    }
}