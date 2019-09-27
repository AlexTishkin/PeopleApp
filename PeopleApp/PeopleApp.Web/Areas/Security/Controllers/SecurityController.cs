using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PeopleApp.Infrastructure;
using PeopleApp.Web.Areas.Security.Models;
using PeopleApp.Web.Areas.Security.Options;
using ApplicationUser = PeopleApp.Core.Entity.ApplicationUser;

namespace PeopleApp.Web.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;
        private readonly ApplicationDbContext _context;

        public SecurityController(
            UserManager<ApplicationUser> userManager,
            IOptions<ApplicationSettings> appSettings,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _context = context;
        }

        [HttpPost]
        [Route("/login")]
        //POST : /api/login
        public async Task<IActionResult> Login(LoginVm model)
        {
            var user = await _userManager.FindByNameAsync(model.Login);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = null, //DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new {token});
            }

            return BadRequest(new {message = "Username or password is incorrect."});
        }

        
    }
}