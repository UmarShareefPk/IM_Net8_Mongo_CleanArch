using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;
using AuthAndUser.Domain.Models;
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


        public async Task AddAsync(User user) => await _users.InsertOneAsync(user);

        public Task<List<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByEmailAsync(string email) =>
            await _users.Find(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<User> GetByIdAsync(string id)
        {
            //ObjectId.TryParse to validate input
            if (!ObjectId.TryParse(id, out var objectId))
                return null;

            return await _users
                .Find(user => user.Id == objectId.ToString())
                .FirstOrDefaultAsync();
        }

        public async Task<UsersWithPage> GetUsersPageAsync(int pageSize, int pageNumber, string? sortBy, string? sortDirection, string? search)
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

            return new UsersWithPage
            {
                Users = users,
                Total_Users = totalCount
              
            };
        }

        public Task RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
