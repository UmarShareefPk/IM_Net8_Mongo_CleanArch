using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Shared.MongoInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMongoCollection<UserLogin> _userloginsCollection;

        public AuthRepository(IMongoDbContext context)
        {
            _userloginsCollection = context.GetCollection<UserLogin>("userlogins");
        }


        public async Task AddAsync(UserLogin userLogin) => await _userloginsCollection.InsertOneAsync(userLogin);

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLogin> GetByUsernameAndPasswordAsync(string username, string password)
        {          
              return await _userloginsCollection
                .AsQueryable()
                .Where(x => x.Username == username && x.Password == password)
                .FirstOrDefaultAsync();
        }

        public Task<string> GetHubIdByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetHubIdsAsync(string incidentId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByUserIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string userId, UserLogin updatedLoginUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHubIdAsync(string userId, string hubId)
        {
            throw new NotImplementedException();
        }
    }
}
