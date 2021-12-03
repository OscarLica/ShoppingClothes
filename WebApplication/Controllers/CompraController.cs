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
    public class CompraController : ControllerBase
    {
        private readonly IServiceCompra Service;
        public CompraController(IServiceCompra service)
        {
            Service = service;
        }

        [HttpPost]
        public IActionResult Create([FromForm] Compra compra) {
            return Ok(Service.Post(compra));
        }

        [HttpGet]
        public IActionResult GetProductosComprados()
        {
            return Ok(Service.GetProductosComprados());
        }
    }
}
