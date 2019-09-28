using System;
using System.Collections.Generic;
using System.Text;
using PeopleApp.Infrastructure.Services.VKBot.Models;

namespace PeopleApp.Infrastructure.Services.VKBot
{
    public interface IVKService
    {
        string GetHandledMessage(string message);
    }
}
