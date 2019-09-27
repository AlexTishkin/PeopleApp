using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public RegionRepository(DbContext context) : base(context) {}
    }
}