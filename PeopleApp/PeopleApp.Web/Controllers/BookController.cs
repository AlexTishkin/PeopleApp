using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Core.Dto;
using PeopleApp.Core.Entity;
using PeopleApp.Infrastructure;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace PeopleApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BookController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Book
        [Authorize]
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Get()
        {
            var allBooks = _uow.Books.GetAll();
            var bookVms = Mapper.Map<IEnumerable<BookDto>>(allBooks);
            return Ok(bookVms);
        }

        // GET: api/Book/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _uow.Books.Get(id);
            return Ok(Mapper.Map<BookDto>(book));
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] BookDto book)
        {
            _uow.Books.Add(Mapper.Map<Book>(book));
            _uow.SaveChanges();
        }

        // PUT: api/Book/Update/1
        [HttpPost("{action}/{id}")]
        public void Update(int id, [FromBody] BookDto book)
        {
            var t = _uow.Books.Get(id);
            t.Name = book.Name;
            var result = _uow.SaveChanges();
        }

        // DELETE: api/Book/Delete/1
        [HttpPost("{action}/{id}")]
        public void Delete(int id)
        {
            _uow.Books.Remove(_uow.Books.Get(id));
            _uow.SaveChanges();
        }
    }
}