using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public RegionRepository(DbContext context) : base(context) {}

        public override Region Get(Guid id, bool eagerMode = false)
        {
            var region = _entities.Find(id);

            if (eagerMode)
            {
                _appContext.Entry(region).Collection(t => t.BirthRates).Load();
                _appContext.Entry(region).Collection(t => t.DeathRates).Load();
            }

            return region;
        }

        public IEnumerable<Region> GetAll(bool eagerMode = false)
        {
            if (!eagerMode) return _entities.ToList();

            var entities = _entities
                .Include(e => e.BirthRates)
                .Include(e => e.DeathRates)
                .ToList();

            return entities;
        }
    }
}