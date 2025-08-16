using AuthAndUser.Application.Users.Commands;
using AuthAndUser.Application.Users.Queries;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AuthAndUser.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("User module is alive");

        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
    

        public UsersController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;                     
            _userRepository = userRepository;
        }

        
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int pageSize = 5, int pageNumber = 1, string sortBy = null!, string sortDirection = "asc", string? search = "")
        {
            var result = await _mediator.Send(new GetUsersPageQuery(pageSize, pageNumber, sortBy, sortDirection, search));

            if (result is null || result.TotalCount == 0)
                return NotFound("No users found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserCommand command)
        {
            if (id != command.Id) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _mediator.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
            return user is not null ? Ok(user) : NotFound();
        }


        [HttpGet("getAllTeamUsers")]
        public async Task<IActionResult> GetAllTeamUser(string teamId)
        {
            var users = await _mediator.Send(new GetAllTeamUsersQuery { TeamId = teamId });
            return users is not null ? Ok(users) : NotFound();
        }

    }// end of class
    
}
