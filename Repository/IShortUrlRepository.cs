using shortenUrl.Models;

namespace shortenUrl.Repository
{
    public interface IShortUrlRepository
    {
        Task Create(ShortUrl shortUrl);
        Task<ShortUrl> GetByShortCode(string shortCode);
    }
}
