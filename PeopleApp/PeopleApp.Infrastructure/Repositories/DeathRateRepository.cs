using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class DeathRateRepository : Repository<DeathRate>, IDeathRateRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public DeathRateRepository(DbContext context) : base(context) {}
    }
}