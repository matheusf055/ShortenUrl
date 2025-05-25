using Microsoft.EntityFrameworkCore;
using shortenUrl.Data;
using shortenUrl.Models;

namespace shortenUrl.Repository
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly ShortUrlContext _shortUrlContext;

        public ShortUrlRepository(ShortUrlContext shortUrlContext)
        {
            _shortUrlContext = shortUrlContext;
        }

        public async Task Create(ShortUrl shortUrl)
        {
            _shortUrlContext.ShortUrls.Add(shortUrl);
            await _shortUrlContext.SaveChangesAsync();
        }

        public async Task<ShortUrl> GetByShortCode(string shortCode)
        {
            return await _shortUrlContext.ShortUrls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);
        }
    }
}
