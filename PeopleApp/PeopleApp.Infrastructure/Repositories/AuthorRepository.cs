using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public AuthorRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Author> GetAll()
        {
            return _entities
                .Include(e => e.Books)
                .ToList();
        }

        public override Author Get(int id)
        {
            var author = _entities.Find(id);
            _appContext.Entry(author).Collection(t => t.Books).Load();
            return author;
        }
    }
}