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

        public override IEnumerable<Okrug> GetAll(bool eagerMode = false)
        {
            return _entities.ToList();
        }

        public override Okrug Get(Guid id, bool eagerMode = false)
        {
            var okrug = _entities.Find(id);

            if (eagerMode)
            {
                _appContext.Entry(okrug).Collection(t => t.Regions).Load();
            }

            return okrug;
        }
    }
}