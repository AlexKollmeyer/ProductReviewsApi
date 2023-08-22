using Microsoft.EntityFrameworkCore;

namespace Products_ReviewsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
