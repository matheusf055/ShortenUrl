namespace shortenUrl.Models
{
    public class ShortUrl
    {
        public ShortUrl() { }

        public ShortUrl(string originalUrl)
        {
            OriginalUrl = originalUrl;
            ShortCode = GenerateShortCode();
        }

        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortCode { get; private set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        private static string GenerateShortCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }
    }
}
