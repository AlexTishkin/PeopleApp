using System;

namespace PeopleApp.Infrastructure.Services.VKBot
{
    public class VKService : IVKService
    {
        public string GetHandledMessage(string message)
        {
            if (message.Equals("привет", StringComparison.OrdinalIgnoreCase))
            {
                return "Добрый день! :-)";
            }

            return $"Сам1 {message}!";
        }
    }
}