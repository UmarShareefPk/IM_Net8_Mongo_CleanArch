using Auth.Application.Commands;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.MongoInfrastructure;
using Shared.MongoInfrastructure.Interfaces;
using System.Text;

namespace APIHost
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration config)
        {

            // Shared Mongo configuration
            // Build MongoSettings object manually so that sesitive data can be kept in environment variables
            var mongoSettings = new MongoSettings
            {
                ConnectionString = config["MongoConnectionString"]
                    ?? throw new InvalidOperationException("MongoConnectionString is not configured."),
                DatabaseName = config["MongoDatabaseName"]
                    ?? throw new InvalidOperationException("MongoDatabaseName is not configured.")
            };


            services.AddSingleton(mongoSettings);
            services.AddSingleton<IMongoDbContext, MongoDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();

            // MediatR            
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
            });

            //JWT
            var jwtSettings = config.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(config["JwtSecret"]!);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings["Issuer"],

                    ValidateAudience = true,
                    ValidAudience = jwtSettings["Audience"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


            // Register Swagger generator
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                // Add the JWT bearer definition
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by your access token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIs...\""
                });

                // Apply it globally to all operations
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });

            return services;
        }
    }
}
