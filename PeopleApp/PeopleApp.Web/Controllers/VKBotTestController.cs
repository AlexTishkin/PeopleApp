using System;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Infrastructure.Services.VKBot;

namespace PeopleApp.Web.Controllers
{
    [Route("api/vk")]
    [ApiController]
    public class VKBotTestController : ControllerBase
    {
        private readonly IVKService _vkService;

        public VKBotTestController(IVKService vkService)
        {
            _vkService = vkService;
        }

        [HttpGet]
        public IActionResult Get(string message)
        {
            if (message == null) throw new ArgumentException();
            message = message.ToLower();
            var handledMessage = _vkService.GetHandledMessage(message);
            return Ok(handledMessage);
        }

    }
}