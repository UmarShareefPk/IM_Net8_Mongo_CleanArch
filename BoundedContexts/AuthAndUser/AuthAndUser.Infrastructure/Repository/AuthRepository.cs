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

namespace AuthAndUser.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMongoCollection<UserLogin> _userloginsCollection;

        public AuthRepository(IMongoDbContext context)
        {
            _userloginsCollection = context.GetCollection<UserLogin>("userlogins");
        }


       

        public async Task<UserLogin> GetByUsernameAndPasswordAsync(string username, string hasedPassword)
        {          
              return await _userloginsCollection
                .AsQueryable()
                .Where(x => x.Username == username && x.Password == hasedPassword)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _userloginsCollection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<UserLogin?> GetByIdAsync(string id) =>
         await _userloginsCollection.Find(u => u.Id == id).FirstOrDefaultAsync();

        Task<string> GetHubIdByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        Task<List<string>> GetHubIdsAsync(string incidentId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(UserLogin userLogin)
            => await _userloginsCollection.InsertOneAsync(userLogin);

        public async Task UpdateAsync(UserLogin userLogin)
            => await _userloginsCollection.ReplaceOneAsync(x => x.Id == userLogin.Id, userLogin);

        Task<bool> UpdateHubIdAsync(string userId, string hubId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthRepository.UpdateHubIdAsync(string userId, string hubId)
        {
            return UpdateHubIdAsync(userId, hubId);
        }

        Task<List<string>> IAuthRepository.GetHubIdsAsync(string incidentId, string userId)
        {
            return GetHubIdsAsync(incidentId, userId);
        }

        Task<string> IAuthRepository.GetHubIdByUserIdAsync(string userId)
        {
            return GetHubIdByUserIdAsync(userId);
        }
    }
}
