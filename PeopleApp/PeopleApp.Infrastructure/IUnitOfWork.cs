namespace PeopleApp.Infrastructure
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        int SaveChanges();
    }
}