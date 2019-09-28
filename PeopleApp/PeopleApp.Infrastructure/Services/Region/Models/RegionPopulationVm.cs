using System;

namespace PeopleApp.Infrastructure.Services.Region.Models
{
    public class RegionPopulationVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public RegionPopulationVm(Guid id, string name, int population)
        {
            Id = id;
            Name = name;
            Population = population;
        }
    }
}
