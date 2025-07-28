using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Repositories;
using AuthAndUser.Infrastructure.MongoModels;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Shared.MongoInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserDocument> _users;
        private readonly IMapper _mapper;

        public UserRepository(IMongoDbContext context, IMapper mapper)
        {
            _users = context.GetCollection<UserDocument>("users");
            _mapper = mapper;
        }


        public async Task<User?> GetByEmailAsync(string email)
        {
            var doc = await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
            return doc is not null ? _mapper.Map<User>(doc) : null;
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            var doc = await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
            return doc is not null ? _mapper.Map<User>(doc) : null;
        }

        public async Task DeleteAsync(string id) =>
         await _users.DeleteOneAsync(u => u.Id == id);

        public async Task<List<User>> GetAllUsersAsync()
        {
            var docs = await _users.Find(_ => true).ToListAsync();
            return _mapper.Map<List<User>>(docs);
        }


        public async Task InsertAsync(User user)
        {
            var document = _mapper.Map<UserDocument>(user);
            await _users.InsertOneAsync(document);
        }


        public async Task UpdateAsync(User user)
        {
            var doc = _mapper.Map<UserDocument>(user);
            await _users.ReplaceOneAsync(u => u.Id == user.Id, doc);
        }

        public async Task<(List<User> users, long recordCount)> GetUsersPageAsync(
    int pageSize, int pageNumber, string? sortBy, string? sortDirection, string? search)
        {
            var filterBuilder = Builders<UserDocument>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrWhiteSpace(search))
            {
                filter = Builders<UserDocument>.Filter.Or(
                    Builders<UserDocument>.Filter.Regex(u => u.FirstName, new BsonRegularExpression(search, "i")),
                    Builders<UserDocument>.Filter.Regex(u => u.LastName, new BsonRegularExpression(search, "i")),
                    Builders<UserDocument>.Filter.Regex(u => u.Email, new BsonRegularExpression(search, "i"))
                );
            }

            var totalCount = await _users.CountDocumentsAsync(filter);

            var sortDefinition = Builders<UserDocument>.Sort.Descending(u => u.CreatedAt);

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                var ascending = sortDirection?.ToLower() == "asc";

                sortDefinition = sortBy.ToLower() switch
                {
                    "firstname" => ascending
                        ? Builders<UserDocument>.Sort.Ascending(u => u.FirstName)
                        : Builders<UserDocument>.Sort.Descending(u => u.FirstName),

                    "email" => ascending
                        ? Builders<UserDocument>.Sort.Ascending(u => u.Email)
                        : Builders<UserDocument>.Sort.Descending(u => u.Email),

                    _ => sortDefinition
                };
            }

            var skip = (pageNumber - 1) * pageSize;

            var docs = await _users
                .Find(filter)
                .Sort(sortDefinition)
                .Skip(skip)
                .Limit(pageSize)
                .ToListAsync();

            var users = _mapper.Map<List<User>>(docs);

            return (users, totalCount);
        }


    }
}
