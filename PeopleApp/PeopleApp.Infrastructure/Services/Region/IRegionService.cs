using System;
using System.Collections.Generic;
using System.Text;
using PeopleApp.Infrastructure.Services.Region.Models;

namespace PeopleApp.Infrastructure.Services.Region
{
    public interface IRegionService
    {
        IEnumerable<RegionTypeVm> GetRegions();
        List<Dictionary<string, int>> GetRegion(Guid id, string[] fields);
        IEnumerable<RegionPopulationVm> GetPopulation();
    }
}
