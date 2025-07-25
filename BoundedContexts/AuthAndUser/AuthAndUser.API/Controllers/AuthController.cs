using AuthAndUser.Application.Commands;
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
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Auth module is alive");

        private readonly IMediator _mediator;  
    
        public AuthController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;          
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthenticateCommand authenticateCommand)        
        {
            var authenticateResponse = await _mediator.Send(authenticateCommand);

            if( authenticateResponse == null)            
                return Unauthorized();
            
            return Ok(authenticateResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand cmd)
        {
            var userId = await _mediator.Send(cmd);
            return Ok(new { UserId = userId });
        }
    }
    
}
