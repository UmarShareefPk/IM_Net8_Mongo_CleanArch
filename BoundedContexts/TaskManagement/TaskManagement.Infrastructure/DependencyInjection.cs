
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Repositories;
using TaskManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;



namespace TaskManagement.Infrastructure
{
    public static class DependencyInjection
    {
             
        public static IServiceCollection AddTaskManagementInfrastructure(this IServiceCollection services, IConfiguration config)
        {          
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            //services.AddScoped<ICommentRepository, comme>();

                    


            return services;
        }
    }
}
