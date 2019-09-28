using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Core.Dto;
using PeopleApp.Infrastructure.Services.Region;
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer.Types;
using PeopleApp.Infrastructure;

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
        public IActionResult GetRegions()
        {
            var items = _uow.CensusPlaces.GetAll();
            return Ok(Mapper.Map<IEnumerable<CensusPlaceDto>>(items));
        }
    }
}