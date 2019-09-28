using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApp.Infrastructure.Services.Region.Models
{
    public enum RegionType
    {
        // Россия
        Russia = 0,
        // Округ
        Okrug = 1,
        // Область
        Region = 2
    }

    public class RegionTypeVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public RegionType Type { get; set; }

        public RegionTypeVm(Guid id, string name, RegionType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
