
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuthAndUser.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;       

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;          
        }

        // GET: api/teams
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        // GET: api/teams/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        // POST: api/teams
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Team team)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            team.CreatedAt = DateTime.UtcNow;
            team.UpdatedAt = DateTime.UtcNow;

            await _teamRepository.CreateAsync(team);

            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        // PUT: api/teams/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Team team)
        {
            var existing = await _teamRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            team.Id = id; // ensure correct ID
            team.UpdatedAt = DateTime.UtcNow;

            await _teamRepository.UpdateAsync(team);
            return NoContent();
        }

        // DELETE: api/teams/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _teamRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _teamRepository.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/teams/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveTeams()
        {
            var teams = await _teamRepository.GetActiveTeamsAsync();
            return Ok(teams);
        }
    }
}
