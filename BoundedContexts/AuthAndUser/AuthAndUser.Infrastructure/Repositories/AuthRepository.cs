using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Repositories;
using AuthAndUser.Infrastructure.MongoModels;
using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Shared.MongoInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMongoCollection<UserLoginDocument> _userlogins;
        private readonly IMapper _mapper;

        public AuthRepository(IMongoDbContext context, IMapper mapper)
        {
            _userlogins = context.GetCollection<UserLoginDocument>("user_logins");
            _mapper = mapper;
        }


       

        public async Task<UserLogin> GetByUsernameAndPasswordAsync(string username, string hasedPassword)
        {
            //return await _userloginsCollection
            //  .AsQueryable()
            //  .Where(x => x.Username == username && x.Password == hasedPassword)
            //  .FirstOrDefaultAsync();
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _userlogins.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<UserLogin?> GetByIdAsync(string id)
        {
            var mongoModel = await _userlogins.Find(x => x.Id == id).FirstOrDefaultAsync();
            return mongoModel == null ? null : _mapper.Map<UserLogin>(mongoModel);
        }

        public async Task InsertAsync(UserLogin userLogin)
        {
            var mongoModel = _mapper.Map<UserLoginDocument>(userLogin);
            await _userlogins.InsertOneAsync(mongoModel);
        }

        public async Task UpdateAsync(UserLogin userLogin)
        {
            var mongoModel = _mapper.Map<UserLoginDocument>(userLogin);
            await _userlogins.ReplaceOneAsync(x => x.Id == mongoModel.Id, mongoModel);
        }

        Task<string> GetHubIdByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        Task<List<string>> GetHubIdsAsync(string incidentId, string userId)
        {
            throw new NotImplementedException();
        }

      
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

        public async Task<UserLogin?> GetByUsernameAsync(string username)
        {
            
            var mongoModel = await _userlogins.Find(x => x.Username == username).FirstOrDefaultAsync();
            return mongoModel == null ? null : _mapper.Map<UserLogin>(mongoModel);
        }
    }
}
