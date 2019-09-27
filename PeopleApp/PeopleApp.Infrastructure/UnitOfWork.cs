using PeopleApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PeopleApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        private IOkrugRepository _okrugs;
        private IRegionRepository _regions;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IOkrugRepository Okrugs
        {
            get
            {
                if (_okrugs == null) _okrugs = new OkrugRepository(_context);
                return _okrugs;
            }
        }

        public IRegionRepository Regions
        {
            get
            {
                if (_regions == null) _regions = new RegionRepository(_context);
                return _regions;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}