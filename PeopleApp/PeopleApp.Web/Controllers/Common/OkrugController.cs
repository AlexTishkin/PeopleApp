using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Core.Dto;
using PeopleApp.Core.Entity;
using PeopleApp.Infrastructure;
using System.Collections.Generic;

namespace PeopleApp.Web.Controllers
{
    [Route("api/common/[controller]")]
    [ApiController]
    public class OkrugController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public OkrugController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Okrug
        [HttpGet]
        public IActionResult Get()
        {
            var allOkrugs = _uow.Okrugs.GetAll();
            var okrugVms = Mapper.Map<IEnumerable<OkrugDto>>(allOkrugs);
            return Ok(okrugVms);
        }

        // GET: api/Okrug/1
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var okrug = _uow.Okrugs.Get(id);
            return Ok(Mapper.Map<OkrugDto>(okrug));
        }

        // POST: api/Okrug
        [HttpPost]
        public void Post([FromBody] OkrugDto okrug)
        {
            _uow.Okrugs.Add(Mapper.Map<Okrug>(okrug));
            _uow.SaveChanges();
        }

        // PUT: api/Okrug/Update/1
        [HttpPost("{action}/{id}")]
        public void Update(Guid id, [FromBody] OkrugDto okrug)
        {
            var t = _uow.Okrugs.Get(id);
            t.Name = okrug.Name;
            var result = _uow.SaveChanges();
        }

        // DELETE: api/Okrug/Delete/1
        [HttpPost("{action}/{id}")]
        public void Delete(Guid id)
        {
            _uow.Okrugs.Remove(_uow.Okrugs.Get(id));
            _uow.SaveChanges();
        }
    }
}