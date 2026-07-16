using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.Services;
using Product.Mappers;
using Product.DTO;

namespace Product.Controller
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
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

        [HttpGet("category")]
        public IActionResult GetCategory()
        {
            return Ok(_service.GetCategory());
        }

        [HttpGet("active")]
        public IActionResult GetAllActive()
        {
            return Ok(_service.GetAllActive());
        }

        [HttpGet("active" + "/{CategoryId}")]
        public IActionResult GetAllActiveCategory(int CategoryId)
        {
            return Ok(_service.GetAllActiveCategory(CategoryId));
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(ProductDto dto)
        {
            var model = ProductMapper.ParaModel(dto);
            var created = _service.Add(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}