using AuthAndUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string id);
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);

        Task<User?> GetByEmailAsync(string email);   
    
        Task<List<User>> GetAllUsersAsync();
        Task<List<User>> GetAllTeamUsersAsync(string teamId);
        Task<(List<User> users, long recordCount) > GetUsersPageAsync(int pageSize, int pageNumber, string? sortBy, string? sortDirection, string? search);
       

    }
}
