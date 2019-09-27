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
            _context.Okrugs.RemoveRange(_context.Okrugs.ToList());
            _context.Regions.RemoveRange(_context.Regions.ToList());
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
            if (_context.Okrugs.Any()) return;

            var r1 = new Region {Id = Guid.NewGuid(), Name = "Орловская область"};
            var r2 = new Region {Id = Guid.NewGuid(), Name = "Воронежская область"};

            var r3 = new Region {Id = Guid.NewGuid(), Name = "Ленинградская область"};
            var r4 = new Region {Id = Guid.NewGuid(), Name = "Мурманская область"};

            var o1 = new Okrug
            {
                Id = Guid.NewGuid(),
                Name = "Центральный федеральный округ",
                Regions = new List<Region> {r1, r2}
            };

            var o2 = new Okrug
            {
                Id = Guid.NewGuid(),
                Name = "Северо-Западный федеральный округ",
                Regions = new List<Region> {r3, r4}
            };

            _context.Okrugs.AddRange(o1, o2);

            _context.SaveChanges();
        }
    }
}