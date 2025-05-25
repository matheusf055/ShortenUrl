using shortenUrl.Models;

namespace shortenUrl.Services
{
    public interface IShortUrlService
    {
        Task<ShortUrl> ShortenUrl(string originalUrl);
        Task<ShortUrl> GetOriginalUrl(string shortCode);
    }
}
