namespace PeopleApp.Infrastructure
{
    public interface IUnitOfWork
    {
        IOkrugRepository Okrugs { get; }
        IRegionRepository Regions { get; }
        IBirthRateRepository BirthRates { get; }
        IDeathRateRepository DeathRates { get; }
        int SaveChanges();
    }
}