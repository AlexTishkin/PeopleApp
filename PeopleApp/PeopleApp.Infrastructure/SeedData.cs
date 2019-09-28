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
            _context.BirthRates.RemoveRange(_context.BirthRates.ToList());
            _context.DeathRates.RemoveRange(_context.DeathRates.ToList());
            _context.CensusPlaces.RemoveRange(_context.CensusPlaces.ToList());
            _context.NewsArticles.RemoveRange(_context.NewsArticles.ToList());
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

            #region Округа и Регионы

            var r1 = new Region
            {
                Id = Guid.NewGuid(),
                Name = "Орловская область",
                Population = 786935,
                BirthRates = new List<BirthRate>
                {
                    new BirthRate {Id = Guid.NewGuid(), Year = 2000, Value = 15628},
                    new BirthRate {Id = Guid.NewGuid(), Year = 2001, Value = 15712}
                },
                DeathRates = new List<DeathRate>
                {
                    new DeathRate {Id = Guid.NewGuid(), Year = 2000, Value = 6931},
                    new DeathRate {Id = Guid.NewGuid(), Year = 2001, Value = 7037}
                }
            };

            var r2 = new Region
            {
                Id = Guid.NewGuid(),
                Name = "Воронежская область",
                Population = 2335380,
                BirthRates = new List<BirthRate>
                {
                    new BirthRate {Id = Guid.NewGuid(), Year = 2000, Value = 18519},
                    new BirthRate {Id = Guid.NewGuid(), Year = 2001, Value = 18469}
                },
                DeathRates = new List<DeathRate>
                {
                    new DeathRate {Id = Guid.NewGuid(), Year = 2000, Value = 43639},
                    new DeathRate {Id = Guid.NewGuid(), Year = 2001, Value = 44143}
                }
            };

            var r3 = new Region {Id = Guid.NewGuid(), Name = "Ленинградская область", Population = 1716868};
            var r4 = new Region {Id = Guid.NewGuid(), Name = "Мурманская область", Population = 795409};

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

            #endregion

            #region Места переписи

            _context.CensusPlaces.Add(new CensusPlace
            {
                Id = Guid.NewGuid(),
                Name = "Менеджмент в Курске",
                Description = "Пункт переписи населения",
                Latitude = 51.7567885365751,
                Longitude = 36.191112367103216
            });

            _context.CensusPlaces.Add(new CensusPlace
            {
                Id = Guid.NewGuid(),
                Name = "Школа 31",
                Description = "Пункт переписи населения (внутри школы)",
                Latitude = 51.75907951886928,
                Longitude = 36.191112367103216
            });

            #endregion

            #region Новости

            _context.NewsArticles.Add(new NewsArticle
            {
                Id = Guid.NewGuid(),
                Name = "Новость 1",
                Text = "Текст новости 1",
                Date = DateTime.Now
            });

            _context.NewsArticles.Add(new NewsArticle
            {
                Id = Guid.NewGuid(),
                Name = "Новость 2",
                Text = "Текст новости 2",
                Date = DateTime.Now
            });

            #endregion

            _context.SaveChanges();
        }
    }
}