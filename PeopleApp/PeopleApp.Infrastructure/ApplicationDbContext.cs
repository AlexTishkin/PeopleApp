using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeopleApp.Core.Entity;

namespace PeopleApp.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Okrug> Okrugs { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<BirthRate> BirthRates { get; set; }
        public DbSet<DeathRate> DeathRates { get; set; }
        public DbSet<CensusPlace> CensusPlaces { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}