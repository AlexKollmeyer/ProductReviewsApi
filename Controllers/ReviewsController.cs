using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_ReviewsAPI.Data;
using Products_ReviewsAPI.DTOs;
using Products_ReviewsAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products_ReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ReviewsController>
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.ToList();
            return StatusCode(200, reviews);
        }
        // GET api/<ReviewsController>/5
        [HttpGet("product/{id}")]
        public IActionResult GetByProductId(int id)
        {
            var reviews = _context.Reviews.Where(r => r.ProductId == id);
            return Ok(reviews);
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return StatusCode(201, review);
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review review)
        {
            var reviewToUpdate = _context.Reviews.Find(id);
            if(reviewToUpdate == null)
            {
                return NotFound();
            }
            reviewToUpdate.Text = review.Text;
            reviewToUpdate.Rating = review.Rating;
            reviewToUpdate.ProductId = review.ProductId;
            _context.SaveChanges();
            return Ok(review);
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reviewToRemove = _context.Reviews.FirstOrDefault(m => m.Id == id);
            if (reviewToRemove == null)
                return NotFound();
            _context.Reviews.Remove(reviewToRemove);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
