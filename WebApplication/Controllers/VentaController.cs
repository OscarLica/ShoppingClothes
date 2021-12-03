﻿using DataEntities;
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
            return Ok(Service.Post(TblVentas));
        }
    }
}