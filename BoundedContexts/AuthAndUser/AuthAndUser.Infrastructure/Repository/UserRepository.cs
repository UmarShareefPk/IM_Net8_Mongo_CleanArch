using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Shared.MongoInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDbContext context)
        {
            _users = context.GetCollection<User>("users");
        }
             

        public async Task<User?> GetByEmailAsync(string email) =>
            await _users.Find(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<User?> GetByIdAsync(string id) =>
         await _users.Find(u => u.Id == id).FirstOrDefaultAsync();

        public async Task DeleteAsync(string id) =>
         await _users.DeleteOneAsync(u => u.Id == id);

        public async Task<List<User>> GetAllUsersAsync() =>
            await _users.Find(_ => true).ToListAsync();


        public async Task InsertAsync(User user) =>
            await _users.InsertOneAsync(user);


        public async Task UpdateAsync(User user) =>
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);

        public async Task<(List<User> users, long recordCount)> GetUsersPageAsync(int pageSize, int pageNumber, string? sortBy, string? sortDirection, string? search)
        {
            var filterBuilder = Builders<User>.Filter;
            var filter = filterBuilder.Empty;

            // If a search term is provided, build a filter to match it against FirstName, LastName, or Email
            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchFilter = Builders<User>.Filter.Or(
                    Builders<User>.Filter.Regex(u => u.FirstName, new BsonRegularExpression(search, "i")),
                    Builders<User>.Filter.Regex(u => u.LastName, new BsonRegularExpression(search, "i")),
                    Builders<User>.Filter.Regex(u => u.Email, new BsonRegularExpression(search, "i"))
                );
                filter = searchFilter;
            }

            var totalCount = await _users.CountDocumentsAsync(filter);

            // Default sort by CreateDate descending
            var sortDefinition = Builders<User>.Sort.Descending(u => u.CreateDate); // default

            // Build custom sort if sortBy field is provided
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                var ascending = sortDirection?.ToLower() == "asc";

                sortDefinition = sortBy.ToLower() switch
                {
                    "firstname" => ascending
                        ? Builders<User>.Sort.Ascending(u => u.FirstName)
                        : Builders<User>.Sort.Descending(u => u.FirstName),

                    "email" => ascending
                        ? Builders<User>.Sort.Ascending(u => u.Email)
                        : Builders<User>.Sort.Descending(u => u.Email),

                    _ => sortDefinition
                };
            }

            var skip = (pageNumber - 1) * pageSize;

            var users = await _users
                .Find(filter)
                .Sort(sortDefinition)
                .Skip(skip)
                .Limit(pageSize)
                .ToListAsync();
                       
            return (users, totalCount);
        }

     
    }
}
