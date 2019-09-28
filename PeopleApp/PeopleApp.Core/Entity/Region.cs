using System;
using System.Collections.Generic;

namespace PeopleApp.Core.Entity
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public Okrug Okrug { get; set; }
        public Guid OkrugId { get; set; }

        public virtual IList<BirthRate> BirthRates { get; set; }
        public virtual IList<DeathRate> DeathRates { get; set; }
    }
}
