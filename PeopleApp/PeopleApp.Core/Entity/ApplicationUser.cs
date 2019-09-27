using Microsoft.AspNetCore.Identity;

namespace PeopleApp.Core.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }
}