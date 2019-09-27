using System;
using System.Collections.Generic;

namespace PeopleApp.Core.Dto
{
    public class OkrugDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IList<RegionDto> Regions { get; set; }
    }
}
