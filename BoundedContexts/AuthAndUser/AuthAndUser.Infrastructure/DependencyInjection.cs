using AuthAndUser.Application.Security;
using AuthAndUser.Infrastructure.Mappings;
using AuthAndUser.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.Logging;
using AuthAndUser.Infrastructure.Repositories;
using AuthAndUser.Domain.Repositories;


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
