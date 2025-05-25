using Microsoft.EntityFrameworkCore;
using shortenUrl.Data;
using shortenUrl.Repository;
using shortenUrl.Services;

namespace shortenUrl.DI
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShortUrlContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
            services.AddScoped<IShortUrlService, ShortUrlService>();
        }
    }
}
