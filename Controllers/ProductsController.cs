using Microsoft.AspNetCore.Mvc;
using Products_ReviewsAPI.Data;
using Products_ReviewsAPI.DTOs;
using Products_ReviewsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products_ReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult GetAll(int ? maxPrice)
        {
            if (maxPrice == null)
            {
                var products = _context.Products.ToList();
                return Ok(products);
            }
            else if(maxPrice != null)
            {
                var products = _context.Products.Where(p => p.Price <= maxPrice).ToList();
                return Ok(products);
            }
            return BadRequest();

        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult GetByProductId(int id)
        {
            var product = _context.Products.Where(r => r.Id == id);
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201,product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var productToUpdate = _context.Products.Find(id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Reviews = product.Reviews;
            _context.SaveChanges();
            return Ok(product);
        }


        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productToRemove = _context.Products.FirstOrDefault(m => m.Id == id);
            if (productToRemove == null)
                return NotFound();
            _context.Products.Remove(productToRemove);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
