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

namespace Auth.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDbContext context)
        {
            _users = context.GetCollection<User>("users");
        }


        public async Task AddAsync(User user) => await _users.InsertOneAsync(user);
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
    }
}
