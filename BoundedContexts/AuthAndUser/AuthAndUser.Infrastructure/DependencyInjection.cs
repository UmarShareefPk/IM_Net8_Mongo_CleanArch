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


           services.AddSingleton(provider =>
            {
                var configExpr = new MapperConfigurationExpression();
                configExpr.AddProfile<MappingProfile>();

                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                return new MapperConfiguration(configExpr, loggerFactory);
            });

            services.AddSingleton<IMapper>(sp =>
            {
                var config = sp.GetRequiredService<MapperConfiguration>();
                return new Mapper(config);
            });



            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            return services;
        }
    }
}
