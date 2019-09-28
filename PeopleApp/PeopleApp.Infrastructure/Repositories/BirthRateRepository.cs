using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class BirthRateRepository : Repository<BirthRate>, IBirthRateRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public BirthRateRepository(DbContext context) : base(context) {}
    }
}