using PeopleApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PeopleApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        private IOkrugRepository _okrugs;
        private IRegionRepository _regions;
        private IBirthRateRepository _birthRates;
        private IDeathRateRepository _deathRates;
        private ICensusPlaceRepository _censusPlaces;
        private INewsArticleRepository _newsArticles;

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

        public IBirthRateRepository BirthRates
        {
            get
            {
                if (_birthRates == null) _birthRates = new BirthRateRepository(_context);
                return _birthRates;
            }
        }

        public IDeathRateRepository DeathRates
        {
            get
            {
                if (_deathRates == null) _deathRates = new DeathRateRepository(_context);
                return _deathRates;
            }
        }

        public ICensusPlaceRepository CensusPlaces
        {
            get
            {
                if (_censusPlaces == null) _censusPlaces = new CensusPlaceRepository(_context);
                return _censusPlaces;
            }
        }

        public INewsArticleRepository NewsArticles
        {
            get
            {
                if (_newsArticles == null) _newsArticles = new NewsArticleRepository(_context);
                return _newsArticles;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}