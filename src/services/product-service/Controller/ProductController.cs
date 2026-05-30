using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.Services;

namespace Product.Controller
{
    [ApiController]
    [Route("product")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("active")]
        public IActionResult GetAllActive()
        {
            return Ok(_service.GetAllActive());
        }
    }
}