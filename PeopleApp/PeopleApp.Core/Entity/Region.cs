using System;

namespace PeopleApp.Core.Entity
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Okrug Okrug { get; set; }
        public Guid OkrugId { get; set; }
    }
}
