using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.MongoInfrastructure.Interfaces;


namespace Shared.MongoInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedMongoInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var mongoSettings = new MongoSettings
            {
                ConnectionString = config["MongoConnectionString"]
                  ?? throw new InvalidOperationException("MongoConnectionString is not configured."),
                DatabaseName = config["MongoDatabaseName"]
                  ?? throw new InvalidOperationException("MongoDatabaseName is not configured.")
            };


            services.AddSingleton(mongoSettings);
            services.AddSingleton<IMongoDbContext, MongoDbContext>();          

            ;
            return services;
        }
    }
}
