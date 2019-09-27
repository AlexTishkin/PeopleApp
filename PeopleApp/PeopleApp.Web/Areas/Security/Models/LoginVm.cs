using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PeopleApp.Web.Areas.Security.Models
{
    public class LoginVm
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}