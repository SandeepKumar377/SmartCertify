namespace SmartCertify.API.Extension
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCorsExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(options =>
                {
                    var frontEndHosts = configuration.GetSection("FrontEndHosts").Get<string[]>();
                    options.WithOrigins(frontEndHosts!).AllowAnyMethod().AllowAnyHeader();
                });
            });
            return services;
        }
    }
}
