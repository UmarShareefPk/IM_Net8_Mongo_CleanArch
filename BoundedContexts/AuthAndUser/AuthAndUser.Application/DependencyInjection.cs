using AuthAndUser.Application.Commands;
using AuthAndUser.Application.Security;
using AuthAndUser.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
            });
            return services;
        }
    }
}
