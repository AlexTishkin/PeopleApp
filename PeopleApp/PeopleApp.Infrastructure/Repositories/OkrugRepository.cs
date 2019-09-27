using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class OkrugRepository : Repository<Okrug>, IOkrugRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public OkrugRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Okrug> GetAll()
        {
            return _entities
                .Include(e => e.Regions)
                .ToList();
        }

        public override Okrug Get(int id)
        {
            var okrug = _entities.Find(id);
            _appContext.Entry(okrug).Collection(t => t.Regions).Load();
            return okrug;
        }
    }
}