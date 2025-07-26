using AuthAndUser.Application.Security;
using AuthAndUser.Domain.Interfaces;
using AuthAndUser.Infrastructure.Repository;
using AuthAndUser.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AuthAndUser.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthInfrastructure(this IServiceCollection services, IConfiguration config)
        {          
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            return services;
        }
    }
}
