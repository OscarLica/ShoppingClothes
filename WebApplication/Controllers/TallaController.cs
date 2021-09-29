using DataEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallaController : ControllerBase
    {
        private readonly IServiceTalla Service;
        public TallaController(IServiceTalla service)
        {
            Service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(Service.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromForm] CatTalla catTalla)
        {
            return Ok(Service.Create(catTalla));
        }

        [HttpGet("Get/{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(Service.Get(Id));
        }

        [HttpGet("Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            Service.Delete(Id);
            return Ok(new { Message = "Registro eliminado"});
        }
    }
}
