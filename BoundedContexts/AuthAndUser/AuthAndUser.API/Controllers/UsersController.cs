using AuthAndUser.Application.Commands;
using AuthAndUser.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.API.Controllers
{
    [Authorize]
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

        [HttpGet("GetUsersWithPage")]
        public async Task<IActionResult> GetUsersWithPageAsync(int pageSize = 5, int pageNumber = 1, string sortBy = null!, string sortDirection = "asc", string? search = "")
        {
            var result = await _mediator.Send(new GetUsersPageCommand(pageSize, pageNumber, sortBy, sortDirection, search));
            return Ok(result);
        }

    }
    
}
