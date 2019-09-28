using System;
using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure.Repositories
{
    public class NewsArticleRepository : Repository<NewsArticle>, INewsArticleRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext) _context;

        public NewsArticleRepository(DbContext context) : base(context) {}
    }
}