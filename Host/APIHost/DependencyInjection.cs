using Auth.Application.Commands;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Repository;
using Shared.MongoInfrastructure;
using Shared.MongoInfrastructure.Interfaces;

namespace APIHost
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration config)
        {

            // Shared Mongo configuration
            services.Configure<MongoSettings>(config.GetSection("MongoSettings"));
            services.AddSingleton<IMongoDbContext, MongoDbContext>();

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
