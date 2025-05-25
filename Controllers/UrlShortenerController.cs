using Microsoft.AspNetCore.Mvc;
using shortenUrl.Services;

namespace shortenUrl.Controllers
{
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IShortUrlService _shortUrlService;

        public UrlShortenerController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] string originalUrl)
        {
            var shortUrl = await _shortUrlService.ShortenUrl(originalUrl);

            var result = $"{Request.Scheme}://{Request.Host}/{shortUrl.ShortCode}";
            return Ok(result);
        }

        [HttpGet("{shortenCode}")]
        public async Task<IActionResult> RedirectToOriginal([FromRoute] string shortenCode)
        {
            var url = await _shortUrlService.GetOriginalUrl(shortenCode);
            return Redirect(url.OriginalUrl);
        }
    }
}
