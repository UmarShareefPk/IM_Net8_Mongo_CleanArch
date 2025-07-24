using AuthAndUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Domain.Interfaces
{
    public interface IAuthRepository
    {
       Task<UserLogin> GetByUsernameAndPasswordAsync(string username, string password);
        Task AddAsync(UserLogin userLogin);
        Task RemoveByUserIdAsync(string id);
        Task UpdateAsync(string userId, UserLogin updatedLoginUser);
        Task<bool> UpdateHubIdAsync(string userId, string hubId);
        Task<List<string>> GetHubIdsAsync(string incidentId, string userId);
        Task<string> GetHubIdByUserIdAsync(string userId);


    }
}
