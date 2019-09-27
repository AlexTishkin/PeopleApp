using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Core.Dto;
using PeopleApp.Core.Entity;
using PeopleApp.Infrastructure;
using System.Collections.Generic;

namespace PeopleApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public AuthorController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Author
        [HttpGet]
        public IActionResult Get()
        {
            var allAuthors = _uow.Authors.GetAll();
            var authorVms = Mapper.Map<IEnumerable<AuthorDto>>(allAuthors);
            return Ok(authorVms);
        }

        // GET: api/Author/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _uow.Authors.Get(id);
            return Ok(Mapper.Map<AuthorDto>(author));
        }

        // POST: api/Author
        [HttpPost]
        public void Post([FromBody] AuthorDto author)
        {
            _uow.Authors.Add(Mapper.Map<Author>(author));
            _uow.SaveChanges();
        }

        // PUT: api/Author/Update/1
        [HttpPost("{action}/{id}")]
        public void Update(int id, [FromBody] AuthorDto author)
        {
            var t = _uow.Authors.Get(id);
            t.Name = author.Name;
            var result = _uow.SaveChanges();
        }

        // DELETE: api/Author/Delete/1
        [HttpPost("{action}/{id}")]
        public void Delete(int id)
        {
            _uow.Authors.Remove(_uow.Authors.Get(id));
            _uow.SaveChanges();
        }
    }
}