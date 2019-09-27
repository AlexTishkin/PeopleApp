using System;
using System.Collections.Generic;

namespace PeopleApp.Core.Entity
{
    public class Okrug
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Region> Regions { get; set; }
    }
}