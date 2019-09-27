namespace PeopleApp.Infrastructure
{
    public interface IUnitOfWork
    {
        IOkrugRepository Okrugs { get; }
        IRegionRepository Regions { get; }
        int SaveChanges();
    }
}