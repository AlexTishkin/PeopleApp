using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Core.Dto;
using PeopleApp.Core.Entity;
using PeopleApp.Infrastructure;
using System.Collections.Generic;

namespace PeopleApp.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CensusPlaceApiController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CensusPlaceApiController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/places
        [Route("/api/places")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _uow.CensusPlaces.GetAll();
            return Ok(Mapper.Map<IEnumerable<CensusPlaceDto>>(items));
        }

        // POST: api/Census
        [Authorize(Roles = "admin")]
        [Route("/api/add-place")]
        [HttpPost]
        public void Post([FromBody] CensusPlaceDto censusPlace)
        {
            _uow.CensusPlaces.Add(Mapper.Map<CensusPlace>(censusPlace));
            _uow.SaveChanges();
        }
    }
}