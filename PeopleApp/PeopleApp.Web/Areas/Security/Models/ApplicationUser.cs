using Microsoft.AspNetCore.Identity;

namespace PeopleApp.Web.Areas.Security.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

    }
}