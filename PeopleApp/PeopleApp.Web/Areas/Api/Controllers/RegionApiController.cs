using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Core.Dto;
using PeopleApp.Infrastructure.Services.Region;
using System;

namespace PeopleApp.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionApiController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionApiController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        // GET: api/regions
        [Route("/api/regions")]
        [HttpGet]
        public IActionResult GetRegions()
        {
            var regions = _regionService.GetRegions();
            return Ok(regions);
        }

        // GET: api/region?id=xxxx-xxxx-xxxxxxxx-xxxx&tableType=(1|2)
        [Route("api/region")]
        [HttpGet]
        public IActionResult GetRegion(Guid id, string tableType)
        {
            return null;
            //var region = _uow.Regions.Get(id);
            //return Ok(Mapper.Map<RegionDto>(region));
        }

    }
}