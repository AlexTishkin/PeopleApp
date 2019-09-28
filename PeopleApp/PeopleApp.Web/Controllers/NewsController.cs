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
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public NewsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/NewsArticle
        [HttpGet]
        public IActionResult Get()
        {
            var allNewsArticles = _uow.NewsArticles.GetAll();
            var newsArticleVms = Mapper.Map<IEnumerable<NewsArticleDto>>(allNewsArticles);
            return Ok(newsArticleVms);
        }

        // GET: api/NewsArticle/1
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var newsArticle = _uow.NewsArticles.Get(id);
            return Ok(Mapper.Map<NewsArticleDto>(newsArticle));
        }

        // POST: api/NewsArticle
        [Authorize(Roles = "admin")]
        [HttpPost]
        public void Post([FromBody] NewsArticleDto newsArticle)
        {
            _uow.NewsArticles.Add(Mapper.Map<NewsArticle>(newsArticle));
            _uow.SaveChanges();
        }

        // PUT: api/NewsArticle/Update/1
        [Authorize(Roles = "admin")]
        [HttpPost("{action}/{id}")]
        public void Update(Guid id, [FromBody] NewsArticleDto newsArticle)
        {
            var t = _uow.NewsArticles.Get(id);
            t.Name = newsArticle.Name;
            t.Text = newsArticle.Text;
            t.Date = newsArticle.Date;
            var result = _uow.SaveChanges();
        }

        // DELETE: api/NewsArticle/Delete/1
        [Authorize(Roles = "admin")]
        [HttpPost("{action}/{id}")]
        public void Delete(Guid id)
        {
            _uow.NewsArticles.Remove(_uow.NewsArticles.Get(id));
            _uow.SaveChanges();
        }
    }
}