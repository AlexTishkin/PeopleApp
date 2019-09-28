using System;

namespace PeopleApp.Infrastructure.Services.VKBot
{
    public class VKService : IVKService
    {
        public string GetHandledMessage(string message)
        {
            return message + $" ({Guid.NewGuid()})";
        }
    }
}