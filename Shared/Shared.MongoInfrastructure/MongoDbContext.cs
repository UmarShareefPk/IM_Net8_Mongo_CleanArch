using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.MongoInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.MongoInfrastructure
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(MongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name) =>
            _database.GetCollection<T>(name);
    }
}
