using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RocVastDotNet.Interfaces;
using RocVastDotNet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RocVastDotNet.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _repository;

        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _repository.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // GET api/values/5
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repository.AddAsync(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // Additional methods for UPDATE and DELETE could follow a similar structure
        // Ensure to implement the corresponding methods in your IRepository<T> and Repository<T> as necessary
    }
}
}

