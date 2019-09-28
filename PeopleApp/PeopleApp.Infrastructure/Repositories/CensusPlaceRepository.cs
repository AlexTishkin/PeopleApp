using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class CensusPlaceRepository : Repository<CensusPlace>, ICensusPlaceRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;
        
        public CensusPlaceRepository(DbContext context) : base(context) {}
    }
}