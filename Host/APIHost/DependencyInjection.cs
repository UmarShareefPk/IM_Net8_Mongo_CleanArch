using Auth.Application.Commands;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Mongo;

namespace APIHost
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration config)
        {
            // Bind Mongo settings
            services.Configure<MongoSettings>(config.GetSection("MongoSettings"));

            // Mongo context + repository
            services.AddSingleton<MongoDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            // MediatR
            
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
            });

            return services;
        }
    }
}
