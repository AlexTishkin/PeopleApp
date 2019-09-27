using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PeopleApp.Core.Entity;
using System.Linq;

namespace PeopleApp.Infrastructure
{
    public interface ISeedData
    {
        Task InitializeAsync();
    }

    public class SeedData : ISeedData
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            ClearDatabase();
            await AddIdentityData();
            AddTestData();
        }

        private void ClearDatabase()
        {
            _context.Roles.RemoveRange(_context.Roles.ToList());
            _context.Users.RemoveRange(_context.Users.ToList());
            _context.Books.RemoveRange(_context.Books.ToList());
            _context.Authors.RemoveRange(_context.Authors.ToList());
            _context.SaveChanges();
        }

        private async Task AddIdentityData()
        {
            var adminRole = new IdentityRole("admin");

            if (await _roleManager.FindByNameAsync("admin") == null)
                await _roleManager.CreateAsync(adminRole);

            if (await _userManager.FindByNameAsync("admin") == null)
            {
                var admin = new ApplicationUser {UserName = "admin", Email = "admin@admin.ru"};
                var result = await _userManager.CreateAsync(admin, "admin");
                if (result.Succeeded) await _userManager.AddToRoleAsync(admin, "admin");
            }
        }

        private void AddTestData()
        {
            if (_context.Books.Any()) return;

            var b1 = new Book {Id = Guid.NewGuid(), Name = "Книга 1"};
            var b2 = new Book {Id = Guid.NewGuid(), Name = "Книга 2"};
            var b3 = new Book {Id = Guid.NewGuid(), Name = "Книга 3"};

            var a1 = new Author() {Id = Guid.NewGuid(), Name = "Автор 1"};
            a1.Books = new List<Book> {b1, b2};

            var a2 = new Author() {Id = Guid.NewGuid(), Name = "Автор 2"};
            a2.Books = new List<Book> {b3};

            _context.Authors.AddRange(a1, a2);

            _context.SaveChanges();
        }
    }
}