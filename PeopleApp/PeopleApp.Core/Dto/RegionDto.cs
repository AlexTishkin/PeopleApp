using System;
using System.Collections.Generic;
using PeopleApp.Core.Entity;

namespace PeopleApp.Core.Dto
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid OkrugId { get; set; }
        public virtual IList<BirthRate> BirthRates { get; set; }
        public virtual IList<DeathRate> DeathRates { get; set; }
    }
}
