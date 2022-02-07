using DataEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IServiceVenta Service;
        public VentaController(IServiceVenta service)
        {
            Service = service;
        }

        [HttpPost]
        public IActionResult Create([FromForm] TblVentas TblVentas)
        {
            return Ok(Service.Post(TblVentas, User.Identity.Name));
        }

        [HttpPost(nameof(ProductoTaller))]
        public IActionResult ProductoTaller([FromForm] ProductoTaller productoTaller)
        {
            return Ok(Service.ProductoTaller(productoTaller));
        }

        [HttpPost(nameof(ProductoTallerSalida))]
        public IActionResult ProductoTallerSalida([FromForm] ProductoTaller productoTaller)
        {
            return Ok(Service.ProductoTallerSalida(productoTaller));
        }

        [HttpGet]
        public IActionResult GetProductoTallerSalida()
        {
            return Ok(Service.GetProductoTallerSalida());
        }

        [HttpGet("/api/Venta/Anular/{IdVenta}")]
        public IActionResult Anular(int IdVenta)
        {
            return Ok(Service.Anular(IdVenta));
        }
    }
}