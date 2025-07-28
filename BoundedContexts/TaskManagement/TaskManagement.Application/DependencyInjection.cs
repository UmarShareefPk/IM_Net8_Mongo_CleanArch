using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Common;
namespace TaskManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTaskManagementApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
            });
            return services;
        }
    }
}
