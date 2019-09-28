using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Core.Dto;
using PeopleApp.Core.Entity;
using PeopleApp.Infrastructure;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace PeopleApp.Web.Controllers
{
    [Route("api/common/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RegionController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Region
        // Authorization works! Example
        //[Authorize]
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Get()
        {
            var allRegions = _uow.Regions.GetAll();
            var regionVms = Mapper.Map<IEnumerable<RegionDto>>(allRegions);
            return Ok(regionVms);
        }

        // GET: api/Region/1
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var region = _uow.Regions.Get(id);
            return Ok(Mapper.Map<RegionDto>(region));
        }

        // POST: api/Region
        [HttpPost]
        public void Post([FromBody] RegionDto region)
        {
            _uow.Regions.Add(Mapper.Map<Region>(region));
            _uow.SaveChanges();
        }

        // PUT: api/Region/Update/1
        [HttpPost("{action}/{id}")]
        public void Update(Guid id, [FromBody] RegionDto region)
        {
            var t = _uow.Regions.Get(id);
            t.Name = region.Name;
            var result = _uow.SaveChanges();
        }

        // DELETE: api/Region/Delete/1
        [HttpPost("{action}/{id}")]
        public void Delete(Guid id)
        {
            _uow.Regions.Remove(_uow.Regions.Get(id));
            _uow.SaveChanges();
        }
    }
}