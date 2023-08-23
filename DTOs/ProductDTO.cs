using Products_ReviewsAPI.Models;

namespace Products_ReviewsAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<Review> Reviews { get; set; } //Nav property
        public double AverageRating { get; set; }
    }
}
