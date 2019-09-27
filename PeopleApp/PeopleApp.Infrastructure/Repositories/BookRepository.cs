using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public BookRepository(DbContext context) : base(context) {}
    }
}