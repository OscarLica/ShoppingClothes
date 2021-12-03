using DataEntities;
using Microsoft.AspNetCore.Authorization;
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
    public class AlmacenController : ControllerBase
    {
        private readonly IServiceAlmacen Service;
        public AlmacenController(IServiceAlmacen service)
        {
            Service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(Service.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromForm] CatAlmacen catAlmacen)
        {
            return Ok(Service.Create(catAlmacen));
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
