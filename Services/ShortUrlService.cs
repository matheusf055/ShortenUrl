using shortenUrl.Models;
using shortenUrl.Repository;

namespace shortenUrl.Services
{
    public class ShortUrlService : IShortUrlService
    {
        private readonly IShortUrlRepository _shortUrlRepository;

        public ShortUrlService(IShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }

        public async Task<ShortUrl> ShortenUrl(string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl))
                throw new ArgumentNullException("Url vazia.");

            var shortUrl = new ShortUrl(originalUrl);
            shortUrl.Id = Guid.NewGuid();

            await _shortUrlRepository.Create(shortUrl);

            return shortUrl;
        }

        public async Task<ShortUrl> GetOriginalUrl(string shortCode)
        {
            if (string.IsNullOrEmpty(shortCode))
                throw new ArgumentNullException("Código vazio.");

            var shortUrl = await _shortUrlRepository.GetByShortCode(shortCode);
            if (shortUrl == null)
                throw new KeyNotFoundException("Url não encontrada.");

            return shortUrl;
        }
    }
}
