using System;
using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public RegionRepository(DbContext context) : base(context) {}

        public override Region Get(Guid id)
        {
            var region = _entities.Find(id);
            _appContext.Entry(region).Collection(t => t.BirthRates).Load();
            _appContext.Entry(region).Collection(t => t.DeathRates).Load();
            return region;
        }
    }
}