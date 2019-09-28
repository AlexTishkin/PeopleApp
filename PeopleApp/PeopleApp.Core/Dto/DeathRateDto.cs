using System;

namespace PeopleApp.Core.Dto
{
    public class DeathRateDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public int Year { get; set; }
        public Guid RegionId { get; set; }
    }
}
