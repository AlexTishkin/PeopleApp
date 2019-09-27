using PeopleApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PeopleApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        private IAuthorRepository _authors;
        private IBookRepository _books;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IAuthorRepository Authors
        {
            get
            {
                if (_authors == null) _authors = new AuthorRepository(_context);
                return _authors;
            }
        }

        public IBookRepository Books
        {
            get
            {
                if (_books == null) _books = new BookRepository(_context);
                return _books;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}