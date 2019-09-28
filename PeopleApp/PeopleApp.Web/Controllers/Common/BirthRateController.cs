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
    public class BirthRateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BirthRateController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/BirthRate
        public IActionResult Get()
        {
            var allBirthRates = _uow.BirthRates.GetAll();
            var birthRateVms = Mapper.Map<IEnumerable<BirthRateDto>>(allBirthRates);
            return Ok(birthRateVms);
        }

        // GET: api/BirthRate/1
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var birthRate = _uow.BirthRates.Get(id);
            return Ok(Mapper.Map<BirthRateDto>(birthRate));
        }

        // POST: api/BirthRate
        [HttpPost]
        public void Post([FromBody] BirthRateDto birthRate)
        {
            _uow.BirthRates.Add(Mapper.Map<BirthRate>(birthRate));
            _uow.SaveChanges();
        }

        // PUT: api/BirthRate/Update/1
        [HttpPost("{action}/{id}")]
        public void Update(Guid id, [FromBody] BirthRateDto birthRate)
        {
            var t = _uow.BirthRates.Get(id);
            t.Value = birthRate.Value;
            t.Year = birthRate.Year;
            var result = _uow.SaveChanges();
        }

        // DELETE: api/BirthRate/Delete/1
        [HttpPost("{action}/{id}")]
        public void Delete(Guid id)
        {
            _uow.BirthRates.Remove(_uow.BirthRates.Get(id));
            _uow.SaveChanges();
        }
    }
}