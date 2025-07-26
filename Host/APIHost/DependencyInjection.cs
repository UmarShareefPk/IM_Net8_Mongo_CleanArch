
using AuthAndUser.Infrastructure;
using AuthAndUser.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.MongoInfrastructure;
using System.Text;
using AuthAndUser.Application;

namespace APIHost
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSharedMongoInfrastructure(config);
            services.AddAuthInfrastructure(config);
            services.AddAuthApplication(config);
           

            var jwtSettings = config.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(config["JwtSecret"]!);

            services.Configure<JwtSettings>(config.GetSection("Jwt"));

            // Bind and inject Secret from environment
            services.PostConfigure<JwtSettings>(options =>
            {
                options.Secret = config["JwtSecret"]!;
            });
           



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
