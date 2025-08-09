
using AuthAndUser.Application;
using AuthAndUser.Infrastructure;
using AuthAndUser.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.MongoInfrastructure;
using System.Text;
using TaskManagement.Infrastructure;
using TaskManagement.Application;
using AutoMapper;

namespace APIHost
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSharedMongoInfrastructure(config);
            services.AddAuthInfrastructure(config);
            services.AddAuthApplication(config);
           services.AddTaskManagementInfrastructure(config); 
            services.AddTaskManagementApplication(config);

            services.AddSingleton(provider =>
             {
                 var configExpr = new MapperConfigurationExpression();
                 configExpr.AddProfile<AuthAndUser.Infrastructure.Mappings.MappingProfile>();
                 configExpr.AddProfile<TaskManagement.Infrastructure.Mappings.MappingProfile>();
                 var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                 return new MapperConfiguration(configExpr, loggerFactory);
             });

            services.AddSingleton<IMapper>(sp =>
            {
                var config = sp.GetRequiredService<MapperConfiguration>();
                return new Mapper(config);
            });

            var jwtSettings = config.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(config["JwtSecret"]!);

            services.Configure<JwtSettings>(config.GetSection("Jwt"));

            // Bind and inject Secret from environment
            services.PostConfigure<JwtSettings>(options =>
            {
                options.Secret = config["JwtSecret"]!;
            });


            services.AddCors(options =>
            {
                options.AddPolicy("ClientPermission", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        //.AllowAnyOrigin()
                        .WithOrigins(
                            "https://localhost:44338",
                            "http://localhost:3000",
                            "http://localhost:4200",
                            "https://lively-bush-0d9b77d10.1.azurestaticapps.net",
                            "http://localhost/ImAngular",
                            "https://calm-mud-02aada210.1.azurestaticapps.net",
                            "https://localhost:7135",
                            "https://salmon-bay-0ee5f3310.1.azurestaticapps.net",
                            "https://immvc6.azurewebsites.net",
                            "https://incidentbyid.azurewebsites.net",
                            "https://green-coast-003a53010.1.azurestaticapps.net"
                            )
                        .AllowCredentials();
                });
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
