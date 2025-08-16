using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Repositories;
using AuthAndUser.Infrastructure.MongoModels;
using AutoMapper;
using MongoDB.Driver;
using Shared.MongoInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IMongoCollection<TeamDocument> _teams;
        private readonly IMapper _mapper;

        public TeamRepository(IMongoDbContext database, IMapper mapper)
        {
            _teams = database.GetCollection<TeamDocument>("teams");
            _mapper = mapper;
        }

        public async Task<Team?> GetByIdAsync(string id)
        {
            var filter = Builders<TeamDocument>.Filter.Eq(t => t.Id, id);
            var teamDoc = await _teams.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<Team?>(teamDoc);
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            var teamDocs = await _teams.Find(_ => true).ToListAsync();
            return _mapper.Map<IEnumerable<Team>>(teamDocs);
        }

        public async Task CreateAsync(Team team)
        {
            var teamDoc = _mapper.Map<TeamDocument>(team);
            await _teams.InsertOneAsync(teamDoc);
        }

        public async Task UpdateAsync(Team team)
        {
            var teamDoc = _mapper.Map<TeamDocument>(team);
            var filter = Builders<TeamDocument>.Filter.Eq(t => t.Id, team.Id);
            await _teams.ReplaceOneAsync(filter, teamDoc);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<TeamDocument>.Filter.Eq(t => t.Id, id);
            await _teams.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Team>> GetActiveTeamsAsync()
        {
            var filter = Builders<TeamDocument>.Filter.Eq(t => t.IsActive, true);
            var teamDocs = await _teams.Find(filter).ToListAsync();
            return _mapper.Map<IEnumerable<Team>>(teamDocs);
        }
    }
}
