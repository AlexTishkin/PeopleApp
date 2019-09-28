using System;

namespace PeopleApp.Core.Entity
{
    public class DeathRate
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public int Year { get; set; }
        public Guid RegionId { get; set; }
    }
}
