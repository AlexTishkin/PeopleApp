using System;

namespace PeopleApp.Core.Dto
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid OkrugId { get; set; }
    }
}
