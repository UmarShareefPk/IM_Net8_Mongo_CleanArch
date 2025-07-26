using AuthAndUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);     
        Task<User?> GetByIdAsync(string id);
        Task<List<User>> GetAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<(List<User> users, long recordCount) > GetUsersPageAsync(int pageSize, int pageNumber, string? sortBy, string? sortDirection, string? search);
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, User updatedUser);

    }
}
