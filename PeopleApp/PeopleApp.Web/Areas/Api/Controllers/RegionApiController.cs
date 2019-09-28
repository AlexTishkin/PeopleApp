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

        // GET: api/region?id=00000000-0000-0000-0000-000000000000&fields=birth&fields=death
        [Route("/api/region")]
        [HttpGet()]
        public IActionResult GetRegion(Guid id, [FromQuery]string[] fields)
        {
            if (fields is null || fields.Length == 0) throw new ArgumentException();
            var result = _regionService.GetRegion(id, fields);
            return Ok(result);
        }

        // GET: api/population
        [Route("/api/population")]
        [HttpGet]
        public IActionResult GetPopulation()
        {
            var result = _regionService.GetPopulation();
            return Ok(result);
        }

    }
}