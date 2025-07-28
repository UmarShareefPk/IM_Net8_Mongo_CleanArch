
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskManagement.Domain.Repositories;
using TaskManagement.Infrastructure.Repositories;
using TaskManagement.Infrastructure.Mappings;
using Microsoft.Extensions.Configuration;



namespace TaskManagement.Infrastructure
{
    public static class DependencyInjection
    {
             
        public static IServiceCollection AddTaskManagementInfrastructure(this IServiceCollection services, IConfiguration config)
        {          
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            //services.AddScoped<ICommentRepository, comme>();


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

                      
            return services;
        }
    }
}
