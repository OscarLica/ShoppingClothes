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
    public class ProductoController : ControllerBase
    {
        private readonly IServiceProducto Service;
        public ProductoController(IServiceProducto service)
        {
            Service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(Service.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromForm] TblProducto producto)
        {
            return Ok(Service.Create(producto));
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
