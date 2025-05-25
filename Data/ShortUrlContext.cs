using Microsoft.EntityFrameworkCore;
using shortenUrl.Models;

namespace shortenUrl.Data
{
    public class ShortUrlContext : DbContext
    {
        public ShortUrlContext(DbContextOptions<ShortUrlContext> options) : base(options) { }

        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
