using Microsoft.EntityFrameworkCore;
using SmartCertify.Infrastructure.Data;

namespace SmartCertify.API.Extension
{
    public static class DBContextExtension
    {
        public static IServiceCollection AddDBContextExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SmartCertifyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            providerOptions => providerOptions.EnableRetryOnFailure()));
            return services;
        }
    }
}
