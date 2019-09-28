using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Core.Dto;
using PeopleApp.Core.Entity;
using PeopleApp.Infrastructure;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace PeopleApp.Web.Controllers.Common
{
    [Route("api/common/[controller]")]
    [ApiController]
    public class DeathRateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public DeathRateController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/DeathRate
        public IActionResult Get()
        {
            var allDeathRates = _uow.DeathRates.GetAll();
            var deathRateVms = Mapper.Map<IEnumerable<DeathRateDto>>(allDeathRates);
            return Ok(deathRateVms);
        }

        // GET: api/DeathRate/1
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var deathRate = _uow.DeathRates.Get(id);
            return Ok(Mapper.Map<DeathRateDto>(deathRate));
        }

        // POST: api/DeathRate
        [HttpPost]
        public void Post([FromBody] DeathRateDto deathRate)
        {
            _uow.DeathRates.Add(Mapper.Map<DeathRate>(deathRate));
            _uow.SaveChanges();
        }

        // PUT: api/DeathRate/Update/1
        [HttpPost("{action}/{id}")]
        public void Update(Guid id, [FromBody] DeathRateDto deathRate)
        {
            var t = _uow.DeathRates.Get(id);
            t.Value = deathRate.Value;
            t.Year = deathRate.Year;
            var result = _uow.SaveChanges();
        }

        // DELETE: api/DeathRate/Delete/1
        [HttpPost("{action}/{id}")]
        public void Delete(Guid id)
        {
            _uow.DeathRates.Remove(_uow.DeathRates.Get(id));
            _uow.SaveChanges();
        }
    }
}