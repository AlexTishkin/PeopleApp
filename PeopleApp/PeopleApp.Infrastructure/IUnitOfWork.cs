namespace PeopleApp.Infrastructure
{
    public interface IUnitOfWork
    {
        IOkrugRepository Okrugs { get; }
        IRegionRepository Regions { get; }
        IBirthRateRepository BirthRates { get; }
        IDeathRateRepository DeathRates { get; }
        ICensusPlaceRepository CensusPlaces { get; }
        INewsArticleRepository NewsArticles { get; }
        int SaveChanges();
    }
}