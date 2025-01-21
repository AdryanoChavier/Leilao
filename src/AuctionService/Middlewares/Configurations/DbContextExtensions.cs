using AuctionService.Data;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Middlewares.Configurations
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddLeilaoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeilaoDbContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
