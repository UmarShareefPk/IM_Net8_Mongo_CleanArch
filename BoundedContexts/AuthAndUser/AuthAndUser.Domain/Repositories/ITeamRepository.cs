using AuthAndUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> GetByIdAsync(string id);
        Task<IEnumerable<Team>> GetAllAsync();
        Task CreateAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(string id);
        Task<IEnumerable<Team>> GetActiveTeamsAsync();
    }
}
