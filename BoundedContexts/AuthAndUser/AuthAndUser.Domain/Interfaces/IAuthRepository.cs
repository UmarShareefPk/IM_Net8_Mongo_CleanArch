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
       Task<UserLogin> GetByUsernameAndPasswordAsync(string username, string hasedPassword);
        Task InsertAsync(UserLogin userLogin);
        Task<UserLogin?> GetByIdAsync(string id);
        Task UpdateAsync(UserLogin userLogin);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateHubIdAsync(string userId, string hubId);
        Task<List<string>> GetHubIdsAsync(string incidentId, string userId);
        Task<string> GetHubIdByUserIdAsync(string userId);


    }
}
